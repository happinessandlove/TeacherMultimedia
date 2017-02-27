CREATE TABLE [dbo].[Buildings] (
    [Id] [uniqueidentifier] NOT NULL,
    [Number] [nvarchar](10) NOT NULL,
    CONSTRAINT [PK_dbo.Buildings] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[ClassRooms] (
    [Id] [uniqueidentifier] NOT NULL,
    [Number] [nvarchar](10) NOT NULL,
    [BuildingId] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_dbo.ClassRooms] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_BuildingId] ON [dbo].[ClassRooms]([BuildingId])
CREATE TABLE [dbo].[Devices] (
    [ClassRoomId] [uniqueidentifier] NOT NULL,
    [Number] [nvarchar](max) NOT NULL,
    [AddTime] [datetime] NOT NULL,
    [AddName] [nvarchar](10),
    [State] [bit] NOT NULL,
    [Remark] [nvarchar](100),
    CONSTRAINT [PK_dbo.Devices] PRIMARY KEY ([ClassRoomId])
)
CREATE INDEX [IX_ClassRoomId] ON [dbo].[Devices]([ClassRoomId])
CREATE TABLE [dbo].[DeviceUseRecords] (
    [Id] [uniqueidentifier] NOT NULL,
    [OpenTime] [datetime] NOT NULL,
    [CloseTime] [datetime] NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceUseRecords] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_UserId] ON [dbo].[DeviceUseRecords]([UserId])
CREATE TABLE [dbo].[Users] (
    [Id] [uniqueidentifier] NOT NULL,
    [RoleId] [uniqueidentifier] NOT NULL,
    [LoginName] [nvarchar](10) NOT NULL,
    [Password] [nvarchar](50) NOT NULL,
    [Name] [nvarchar](20) NOT NULL,
    [LivingAddress] [nvarchar](200),
    [TelephoneNumber] [nvarchar](20),
    [MobileNumber] [nvarchar](20),
    [IDCardNumber] [nvarchar](50),
    [CreateTime] [datetime] NOT NULL,
    [Introduction] [nvarchar](1000),
    [Status] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_RoleId] ON [dbo].[Users]([RoleId])
CREATE TABLE [dbo].[Roles] (
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](20) NOT NULL,
    [MenuId] [nvarchar](max) NOT NULL,
    [Remarks] [nvarchar](100),
    CONSTRAINT [PK_dbo.Roles] PRIMARY KEY ([Id])
)
ALTER TABLE [dbo].[ClassRooms] ADD CONSTRAINT [FK_dbo.ClassRooms_dbo.Buildings_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Buildings] ([Id])
ALTER TABLE [dbo].[Devices] ADD CONSTRAINT [FK_dbo.Devices_dbo.ClassRooms_ClassRoomId] FOREIGN KEY ([ClassRoomId]) REFERENCES [dbo].[ClassRooms] ([Id])
ALTER TABLE [dbo].[DeviceUseRecords] ADD CONSTRAINT [FK_dbo.DeviceUseRecords_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201702251308063_a', N'Models.Migrations.Configuration',  0x1F8B0800000000000400ED5CDB6EE3361ABE5F60DF41F0D576915A490605BA81DD62EA4C8AA0936410A7C5DE05B4C438C24894AB431AA3D827DB8B3ED2BEC2FEB244896751073B49A7981B87878F3FFF33A99FF3BFFFFE31FBFE390A9D279CA4414CE69393E9F1C4C1C48BFD80ACE7933C7BF8FADBC9F7DFFDFD6FB30F7EF4ECFC42C7BD2BC6C14C92CE278F59B63973DDD47BC4114AA751E025711A3F64532F8E5CE4C7EEE9F1F1BFDC93131703C404B01C67769B932C88F0EE0FF87311130F6FB21C8557B18FC3B46A879EE50ED5B946114E37C8C3F3493962E2BC0F0304AB2F71F830711021718632A0EDECE7142FB32426EBE5061A5078B7DD6018F780C21457349F35C36DC93F3E2DC8779B8914CACBD32C8E3A029EBCABF8E18AD37B717552F30B38F601389B6D8B5DEFB8369FFC90076121CE89232E76B60893622065EA940E3D72CA86A35AE2A018C5BF23679187599EE039C17996A0F0C8F994AFC2C0FB096FEFE2CF98CC491E862C3D4011F4710DD0F429893738C9B6B7F8A1A2F2D29F382E3FCF1527D6D3983925FD3FE601FCBE86B5D12AC4B5B45DE3F4EB3C5AE1844280D2EC9874859E3F62B2CE1EC11A40C92F8267ECD3860AF667128085C09C2CC971FBB2D7E82958EF182E10B008519A26711C813ADFE27037247D0C36A5564F77DDB7D07DDF88F02289A3DB38A493B9DEFB3B94AC71061B8AB54396719E78028933B7D119A326D57816AA548FFD4B97C6D42561592AD7AED46B55B2D1B43114926A9B4121A9CEDA12788E9F820252415ED975CF6869439CD827D98A346090A5502A5BCDA41CF80236526FB48FB17093F76935F0731F66F3DEF7EF20FDA00B9FA30C977F77C7297E0C377BF3324B509E7A911F62D057443AD37A0B7944F2D9486A2F5ACDD1ADB4C3A1C62AFA11AD350F3056C81B6FB11727BEB5D5D633BE8C1077B3C16414AB5984718A4741020924A385BE024CA9AA45C7BD20F294D557E50029C2A8470D0A3325C9ADEA5A0CFB3274B4E0F440888FF13A20E378F58E2B7F026FF6DBCE016917FE662F0BB7ECF6742F8B7E0C9E602188A0094E53E3EA6384D03B1CE2CD634C706BCA61B95BF37257F12A080FB4D6E5F902257EEB5A96AAD3E2BA135CFBEA81BEFB926449ECE75E79EB61CA4AC64AA1F246CDA85BA7CDBD83861C16C60B2062D6630E33B61417584A2A8B8EFB620D8EB4A6550A684CD7A0285652D41AC58A615F46147B117F7C85497E698A3D7B3A8B95E712530418FB6052E9781F13104D52611D76269047421A473DD1657A11A27573616D95DC9593871A07F0D3C749B805FE972B808B7E772AD8CC152EE20C259C2C1EB1F71983DAFC82C21C5A8E25317013AEE32442613DFAC43C7A8188879BD1A732734B36B28DEFD334F6821DABC47368736BC5AFF981F84EFB155613389833EB15F035D8002741C8F3C93FA5ED18A16B7FDA4037F76A3CB2CC28705038C1A4F8C2B1001D06A9062493BD5940BC6083C256228499969EB01042BD86D8738EE1C0E80389ADCCB5599CBDE99489A8D7121C751B97662EA32F6635922E2C7492D6DF5E3472A6F783BC948FA75359D006608502697573240DD2D17000FDD1F1D56669C36DE781D4479D03EA44DD9210F2496CBBA8DB80158A245D8AB5B9BA5EEA64DCE70174CAC80E9BF5E90DD48BE81493AEE8E4ADCA5D1A219799B7BDF6A80E03665D1C494FE46D1C4039E4DDDA2C4AAFA00EA01165720973329851674DE7ABB25D913BC266AAF431AD926651D2C5C425CE84A00B796993C84AA98AA42E3C48ED7B55284CBC6A8129AD54854183A915007B00D720314EAF05B23A2A4838A525B44C2E144535B9344A6132A3010ACE32DF639981FAAFB6A26A5A65C035FDBC48253DB7CA79193046C9C47336BF6B0B8EC85F95647E981339BB548E21BFD64B0323B4999B154F7BF04173E32433C3222DE9909830DBA94CC3C014732A227198DDC760FEB0077D9929BAB8DA1659199A2BE3366C5F114BDBD867D828BD69A88341DD3773CB1ABAAA61E66A8AED665768B329CCB09959B538CBB2F26EF1F5B27B795A5462B85EAAA852ABA9AD57CAE204ADB1D00B4B03A517419266E728432B545C8C2CFC481A56873E8DE7A5CB88D14D9612F5C97446F19B5EED73A5728A9CA09A73013B898A6CA2D81456383C79AA53143CA210258AFBC4451CE611D12736FAD9F4D3008B40DB6494992BD02FE5311277042515D96D250CC6FDF59086D6995B88C330F735C84387C25E88B048A68B9217932E0D923D445B6577DDE5AA9BA863287747C072D47879B06F31D7A54A2C4CDDD809A7FCAC20E0948DF638552D128B5235D963D052241684B6BD329535264596BADB9C27FA2AB101613F2EAAA9F561319A567B24A6D887B7A9BAD91E8B5EB6B040BA0B9817D31B5DDED8AA2CBB4363770D514FDB8F5AD0BB0DCE7035F71D7A14A6C28605629AEDB19A9A1916AA69EDE0AE2582BAD22254B4707BE3BBEC31A5BA151655EAB4C7E50B545850BEC71E912F43E1748CEBE9E03A986213CE7730ED1DE8E3EA4D38FAB89E6EA1304FE558982B25FC42EEA83C88F67047BB6BA8EEEE483D6D4F89F46093A5450F9C01546D5DF3995495D01C5E15A49B007148BD7A7D23209CFC67D529BCFD2D9E742C2F874C1C60D053E01747F2E536CD70342D064C97BF868B3080FD3603AE10091E709A95650893D3E39353E169DFEB7966E7A6A91F2A6E31546FED78791DA0D02827C1AF390E8ACF0BC1435038DA416F31C8134ABC47944865AF46D41E2FC9BE4C46C9A8F24B2E9950E97BCE25F1F1F37CF2FB0EE3CCB9FCF77D0373E4DC24606067CEB1F39FB1C4A63A52BFCC73A35ECC61703A70C75603FE11A1E7AF863E45F221B3C946788A64A1969D5F1EAD826CE0AB230D552D64F57EC8F3F67C8BF8C6A6B73A486F6C7A23F16F6C7AD95D09B10F87241F7EDF8498F9672ABD785A420C7263D24B97B16299F8904589FB4D77DC565A4FBB632A9FA168C03BBB4FCDAB130BDAFB3E3219095AF5A6C4428AFD9E90F4764DAA2724BA10D32BF4352F4602D216FBBA3D77787B3E6B1FC6C7BF3918964809EF08C64D3506559537C539BD2ABD15F5347DCBD17BD5DE19BE74EFAF46FC4F5613DE5172ED55E07DABC9873D1B385C99F79FB6AA7B50F5B6549FF82205DB87D302D397D3B7598B3DA8FCDA4A7F46ACB83E5405FEDBA8AB966BD0341F60C4BB6053ED7479610E39F02A06C9966989BE20565B5A6DAEAC562D62283755174E1B0AAF55F89AB2D8B6AA6C9BA26CFD72861A5155E9B6B6725BB582BA225355D4ADADE956C12A0B450F56EE2DEA285F9F6855DBAD2E627E7DB5DC1D0956E65C7275D92B2FD5966A8A2DB629D9A2B210E9D5D4604B65D7AD45E7AD4C19A7CE5AFE8A0A2189F97F4F2114A6C1BA8128FE1754823D2E18D5632EC9434C63A240111D229DAD33E443A47A9FC0811F791974833F4E77765D3DA8FE10ADB07F496EF26C9367B0651CADC22DCB8C22B69AD6DF1593F334CF6E36BB47F5636C01C80C8ACBA11BB2734935DD178ADB170D4411B47FC4D05ECA1272800CAFB735D2754C2C812AF6D5B9C61D8E362180A53764899E701FDA40F53EE235F2B6F463B81EA45D103CDB67E7015A27284A2B8C663EFC093AEC47CFDFFD1F8C81EC51FE570000 , N'6.1.3-40302')

