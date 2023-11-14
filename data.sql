-- AnimalSpec
    INSERT INTO [ZooManagement].[dbo].[AnimalSpecies] ([Id], [Name], [Description], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsDeleted])
VALUES 
    ('EB53DAF3-1476-42FF-B732-01BC2886F074',N'Hổ', N'Loài mèo lớn', GETDATE(), GETDATE(), null, null, 0),
    ('CFA77044-6E67-4A1C-A7F6-0F65783A2180',N'Voi', N'Động vật có vú lớn', GETDATE(), GETDATE(), null, null, 0),
    ('380B81AA-AC18-4175-95A3-242C95926966',N'Hươu cao cổ', N'Động vật có vú cao lớn', GETDATE(), GETDATE(), null, null, 0),
    ('8136F888-41BB-483E-81D3-3A4D03C018B3',N'Chim Cánh Cụt', N'Chim biển không bay', GETDATE(), GETDATE(), null, null, 0),
    ('928163CB-4799-4F88-91A3-4401CF413094', N'Ngựa', N'Động vật có vú chạy nhanh', GETDATE(), GETDATE(), null, null, 0),
    ('7F123FAA-9AB4-4BC2-B9ED-519D4EEF8C8B', N'Cá Heo', N'Động vật biển thông minh', GETDATE(), GETDATE(), null, null, 0),
    ('85F0DAFD-E0D3-46B5-8FBC-6393A495FCCC', N'Chim Cút', N'Chim chạy trên mặt đất', GETDATE(), GETDATE(), null, null, 0),
    ('6E19579D-F892-4C0D-B9E5-6A630D227D9C', N'Lạc Đà', N'Động vật chuyên sống ở sa mạc', GETDATE(), GETDATE(), null, null, 0),
    ('D539FBDF-FCE5-4FB3-B22E-6C640D186245', N'Hổ Sóc', N'Động vật sống ở núi cao', GETDATE(), GETDATE(), null, null, 0),
    ('9587E9CC-9D79-4F62-87BC-7BD00F99EAF6', N'Báo Đốm', N'Loài báo có vẻ ngoài đẹp mắt', GETDATE(), GETDATE(), null, null, 0),
    ('623A7776-3EDD-43DE-A128-84983A681084', N'Tê Giác', N'Động vật có vú lớn sống ở châu Phi', GETDATE(), GETDATE(), null, null, 0),
    ('1E6442ED-7991-480B-A0E0-A06021456CF7', N'Đà điểu', N'Động vật có chân dài và có thể chạy nhanh', GETDATE(), GETDATE(), null, null, 0),
    ('A485F916-BD48-4A37-8C14-B1A88F1C8B8A', N'Sóc', N'Động vật nhỏ thông minh sống trong tự nhiên', GETDATE(), GETDATE(), null, null, 0),
    ('1BD54B0B-2866-4E81-B16D-D71687E283FC', N'Khỉ', N'Động vật thông minh sống trong rừng', GETDATE(), GETDATE(), null, null, 0),
    ('4C8FAB58-70A0-4DB2-A5CB-DE29C36721F1', N'Bò', N'Loài gia súc phổ biến', GETDATE(), GETDATE(), null, null, 0),
    ('E77AE705-E515-41E9-9AE9-FBFC2E10242D', N'Sói', N'Loài thú săn mồi sống đơn độc', GETDATE(), GETDATE(), null, null, 0);



-- Animal
   INSERT INTO [ZooManagement].[dbo].[Animals] 
           ([Id], [Name], [Weight], [Height], [Age], [Gender], [IsHerd], [SpecieId], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsDeleted])
VALUES 
    ('D3A4DE4E-29A5-43E3-A51F-0601442DC4B2', N'Leo', 150, 100, 8, 1, 0, 'EB53DAF3-1476-42FF-B732-01BC2886F074', GETDATE(), GETDATE(), null, null, 0),
    ('199A54BA-DA5B-44F0-A4C6-0C8977439DA2', N'Tom', 20, 50, 3, 0, 1, 'CFA77044-6E67-4A1C-A7F6-0F65783A2180', GETDATE(), GETDATE(), null, null, 0),
    ('B5CEF36A-97FC-453E-A5F2-1C694015944F', N'Jerry', 10, 30, 1, 1, 0, '623A7776-3EDD-43DE-A128-84983A681084', GETDATE(), GETDATE(), null, null, 0),
    ('967B225E-0C3B-4280-8F6D-2C06AF2B4145', N'Pinky', 5, 15, 2, 3, 0, '4C8FAB58-70A0-4DB2-A5CB-DE29C36721F1', GETDATE(), GETDATE(), null, null, 0),
	  ('3D4AF998-FA47-4C09-ABBA-2DCFC4331354', N'Simba', 180, 110, 7, 1, 0, '1E6442ED-7991-480B-A0E0-A06021456CF7', GETDATE(), GETDATE(), null, null, 0),
    ('A46CACF5-8716-4E23-9FAF-2F047E86571D', N'Lilly', 90, 70, 4, 0, 1, 'CFA77044-6E67-4A1C-A7F6-0F65783A2180', GETDATE(), GETDATE(), null, null, 0),
    ('BA43D1FA-6925-4B92-AB55-3EDF4569D343', N'Benny', 15, 35, 2, 1, 0, 'EB53DAF3-1476-42FF-B732-01BC2886F074', GETDATE(), GETDATE(), null, null, 0),
    ('A5C72DC8-66C5-4452-AAF8-4FA6B91A5457', N'Molly', 50, 45, 3, 0, 0, 'CFA77044-6E67-4A1C-A7F6-0F65783A2180', GETDATE(), GETDATE(), null, null, 0),
    ('BF24F95A-6FCE-4792-9D6F-515D412A0CDC', N'Rocky', 110, 90, 6, 1, 0, '380B81AA-AC18-4175-95A3-242C95926966', GETDATE(), GETDATE(), null, null, 0),
    ('CEA4F98B-91C1-4AB2-AE45-543517DB7A5A', N'Bella', 70, 60, 5, 0, 1, '8136F888-41BB-483E-81D3-3A4D03C018B3', GETDATE(), GETDATE(), null, null, 0),
    ('3988595C-05EE-4FA5-BE51-552E8605D72E', N'Toby', 25, 40, 1, 1, 0, '928163CB-4799-4F88-91A3-4401CF413094', GETDATE(), GETDATE(), null, null, 0),
    ('BEDD051F-DD8A-4516-9459-822107A326F7', N'Sophie', 40, 50, 2, 0, 0, '7F123FAA-9AB4-4BC2-B9ED-519D4EEF8C8B', GETDATE(), GETDATE(), null, null, 0),
    ('647491D8-712F-44BC-A5DC-8394EB2C4386', N'Oscar', 85, 75, 4, 1, 0, '85F0DAFD-E0D3-46B5-8FBC-6393A495FCCC', GETDATE(), GETDATE(), null, null, 0),
    ('82150BF9-5711-49B3-A3DC-91842F6347E2', N'Luna', 120, 100, 8, 0, 1, '6E19579D-F892-4C0D-B9E5-6A630D227D9C', GETDATE(), GETDATE(), null, null, 0),
	  ('CA93BF1F-8EA9-48EE-A89B-98D8B267FA6E', N'Max', 70, 60, 5, 1, 0, 'D539FBDF-FCE5-4FB3-B22E-6C640D186245', GETDATE(), GETDATE(), null, null, 0),
    ('0DE3163A-FC2E-4C89-80DD-B5BE64FF5402', N'Sasha', 55, 50, 3, 0, 1, '9587E9CC-9D79-4F62-87BC-7BD00F99EAF6', GETDATE(), GETDATE(), null, null, 0),
    ('AE2824AB-1171-434E-B22D-C07535824D24', N'Rufus', 30, 40, 2, 1, 0, '623A7776-3EDD-43DE-A128-84983A681084', GETDATE(), GETDATE(), null, null, 0),
    ('721427D2-0679-4482-8E77-C099F7F30CB6', N'Lola', 45, 55, 4, 0, 0, '1E6442ED-7991-480B-A0E0-A06021456CF7', GETDATE(), GETDATE(), null, null, 0),
    ('E9C063E4-CA3C-457C-9EDC-CC0AE090EF09', N'Buddy', 80, 70, 6, 1, 0, 'A485F916-BD48-4A37-8C14-B1A88F1C8B8A', GETDATE(), GETDATE(), null, null, 0),
    ('BB8182AE-420B-4F55-BBCB-D39D965F8D45', N'Cleo', 65, 55, 5, 0, 1, '1BD54B0B-2866-4E81-B16D-D71687E283FC', GETDATE(), GETDATE(), null, null, 0),
    ('68183F0C-CE5F-4673-BCE9-E13D6C7FBFD4', N'Felix', 25, 35, 1, 1, 0, '4C8FAB58-70A0-4DB2-A5CB-DE29C36721F1', GETDATE(), GETDATE(), null, null, 0),
    ('E7AB9827-BC41-4563-9555-E3C2D9860DEF', N'Daisy', 40, 45, 3, 0, 0, 'E77AE705-E515-41E9-9AE9-FBFC2E10242D', GETDATE(), GETDATE(), null, null, 0),
    ('C5ABE286-0117-4446-9D46-E8A5A5194F54', N'Ollie', 75, 65, 7, 1, 0, '4C8FAB58-70A0-4DB2-A5CB-DE29C36721F1', GETDATE(), GETDATE(), null, null, 0),
    ('FF6949F8-1248-4CBE-938A-EA409F79E0E2', N'Mia', 85, 75, 8, 0, 1, 'E77AE705-E515-41E9-9AE9-FBFC2E10242D', GETDATE(), GETDATE(), null, null, 0);



--section

  INSERT INTO [ZooManagement].[dbo].[ZooSections] 
    ([Id], [Name], [Description], [ZooSectionStatus], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsDeleted])
VALUES 
    ('6590A270-3270-4599-BD9F-200BB6CC69B2', N'Khu vực phía bắc sở thú', N'Khu vực chứa các vùng phía bắc của sở thú', 0, GETDATE(), GETDATE(), null, null, 0),
    ('63317DB8-0994-495B-8112-224D985544DC', N'Khu vực trung tâm sở thú', N'Khu vực chứa các vùng trung tâm của sở thú', 0, GETDATE(), GETDATE(), null, null, 0),
    ('0CC05ACE-354B-41CE-8608-565A39C90753', N'Khu vực trên cao sở thú', N'Khu vực chứa các vùng cao giáo của sở thú', 1, GETDATE(), GETDATE(), null, null, 0),
    ('A1D62E3E-2D10-44E2-8316-5D8AAE09AEFC', N'Khu vực phía nam sở thú', N'Khu vực chứa các vùng phía nam của sở thú', 0, GETDATE(), GETDATE(), null, null, 0),
    ('0D96CFC7-FB8C-4650-839C-7D68BD3ECEC8', N'Khu vực phía đông sở thú', N'Khu vực chứa các vùng phía đông của sở thú', 0, GETDATE(), GETDATE(), null, null, 0),
    ('BC17CF99-57A0-4372-96DC-8653CCED4BD9', N'Khu vực phía tây sở thú', N'Khu vực chứa các vùng phía tây của sở thú', 1, GETDATE(), GETDATE(), null, null, 0),
    ('D2C385A3-79E2-486C-B8DF-A4C8D72A6D94', N'Khu vực miền núi sở thú', N'Khu vực chứa các vùng miền núi của sở thú', 0, GETDATE(), GETDATE(), null, null, 0),
    ('53842686-84D3-4893-BCCA-A7828C4B2FEF', N'Khu vực rừng sở thú', N'Khu vực chứa các vùng rừng của sở thú', 1, GETDATE(), GETDATE(), null, null, 0),
    ('49086296-25EE-4CAD-846D-E07A4439A6DD', N'Khu vực sa mạc sở thú', N'Khu vực chứa các vùng sa mạc của sở thú', 0, GETDATE(), GETDATE(), null, null, 0),
    ('A08875E9-B751-4093-B378-F23A015E32FA', N'Khu vực đầm lầy sở thú', N'Khu vực chứa các vùng đầm lầy của sở thú', 0, GETDATE(), GETDATE(), null, null, 0);

-- cage


  INSERT INTO [ZooManagement].[dbo].[Cages] 
    ([Id], [Capacity], [Status], [ZooSectionId], [AnimalSpecieId], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsDeleted])
VALUES 
    ('3A454A0C-9377-421B-9DC1-0042D8089365', 10, 0, '6590A270-3270-4599-BD9F-200BB6CC69B2', 'EB53DAF3-1476-42FF-B732-01BC2886F074', GETDATE(), GETDATE(), null, null, 0),
    ('CFDF3D21-FA83-4978-97BD-08342BEECDC7', 15, 0, '63317DB8-0994-495B-8112-224D985544DC', 'CFA77044-6E67-4A1C-A7F6-0F65783A2180', GETDATE(), GETDATE(), null, null, 0),
    ('0EAC0E96-8D17-40D2-8B31-1C157D222CD3', 8, 0, 'A1D62E3E-2D10-44E2-8316-5D8AAE09AEFC', '380B81AA-AC18-4175-95A3-242C95926966', GETDATE(), GETDATE(), null, null, 0),
    ('42781EBA-74D3-4FB9-9004-2AC3518F694C', 12, 1, '0D96CFC7-FB8C-4650-839C-7D68BD3ECEC8', '8136F888-41BB-483E-81D3-3A4D03C018B3', GETDATE(), GETDATE(), null, null, 0),
    ('2DFC0D88-9A81-4EC3-8853-36423CECCB33', 20, 0, 'D2C385A3-79E2-486C-B8DF-A4C8D72A6D94', '928163CB-4799-4F88-91A3-4401CF413094', GETDATE(), GETDATE(), null, null, 0),
    ('08692E63-15B2-48DE-90DC-366857B4C9D9', 18, 1, '49086296-25EE-4CAD-846D-E07A4439A6DD', '7F123FAA-9AB4-4BC2-B9ED-519D4EEF8C8B', GETDATE(), GETDATE(), null, null, 0),
    ('F8C01860-69C2-4596-A92F-47F732CE9E17', 14, 0, 'A08875E9-B751-4093-B378-F23A015E32FA', '85F0DAFD-E0D3-46B5-8FBC-6393A495FCCC', GETDATE(), GETDATE(), null, null, 0),
    ('EF7B8137-8560-49A7-9481-583AF4D654EA', 9, 1, '6590A270-3270-4599-BD9F-200BB6CC69B2', '6E19579D-F892-4C0D-B9E5-6A630D227D9C', GETDATE(), GETDATE(), null, null, 0),
    ('A42DC0E5-4E68-4E92-BC3D-5E3F3D7D21EB', 16, 0, '63317DB8-0994-495B-8112-224D985544DC', 'D539FBDF-FCE5-4FB3-B22E-6C640D186245', GETDATE(), GETDATE(), null, null, 0),
    ('A6C62263-9947-49BB-9291-7E864E039C0F', 11, 1, 'A1D62E3E-2D10-44E2-8316-5D8AAE09AEFC', '9587E9CC-9D79-4F62-87BC-7BD00F99EAF6', GETDATE(), GETDATE(), null, null, 0),
    ('C4A6DB29-721B-4A99-834D-89AC74CC80DD', 19, 0, '0D96CFC7-FB8C-4650-839C-7D68BD3ECEC8', '623A7776-3EDD-43DE-A128-84983A681084', GETDATE(), GETDATE(), null, null, 0),
    ('EA5DA722-DE43-451F-82F8-8E8902EAB4BE', 13, 1, 'D2C385A3-79E2-486C-B8DF-A4C8D72A6D94', '1E6442ED-7991-480B-A0E0-A06021456CF7', GETDATE(), GETDATE(), null, null, 0),
    ('13505DCA-4D8C-467B-ADD5-A30530333BE2', 17, 0, '49086296-25EE-4CAD-846D-E07A4439A6DD', 'A485F916-BD48-4A37-8C14-B1A88F1C8B8A', GETDATE(), GETDATE(), null, null, 0),
    ('2B60EAD0-C41A-42F9-AE80-B9FCDB30F26B', 7, 1, 'A08875E9-B751-4093-B378-F23A015E32FA', '1BD54B0B-2866-4E81-B16D-D71687E283FC', GETDATE(), GETDATE(), null, null, 0),
    ('DA9C63D0-E60F-4E52-8766-CEA0F441D02E', 21, 0, '6590A270-3270-4599-BD9F-200BB6CC69B2', '4C8FAB58-70A0-4DB2-A5CB-DE29C36721F1', GETDATE(), GETDATE(), null, null, 0),
    ('C953B31B-297C-47DA-A0A5-DEFD85A79785', 10, 1, '63317DB8-0994-495B-8112-224D985544DC', 'E77AE705-E515-41E9-9AE9-FBFC2E10242D', GETDATE(), GETDATE(), null, null, 0),
    ('875B82AF-94A2-4184-A419-EC60D94AA42E', 15, 0, 'A1D62E3E-2D10-44E2-8316-5D8AAE09AEFC', 'EB53DAF3-1476-42FF-B732-01BC2886F074', GETDATE(), GETDATE(), null, null, 0),
    ('D0887C3F-39DF-4036-AABB-F2D1FEE61243', 8, 1, '0D96CFC7-FB8C-4650-839C-7D68BD3ECEC8', '380B81AA-AC18-4175-95A3-242C95926966', GETDATE(), GETDATE(), null, null, 0),
    ('5BA9D1C9-3C9C-45F2-92D4-F79B053A4777', 12, 0, 'D2C385A3-79E2-486C-B8DF-A4C8D72A6D94', '8136F888-41BB-483E-81D3-3A4D03C018B3', GETDATE(), GETDATE(), null, null, 0),
    ('F7DB6C88-B0D9-4F28-ACD7-FA4F77DFB777', 20, 1, '49086296-25EE-4CAD-846D-E07A4439A6DD', '928163CB-4799-4F88-91A3-4401CF413094', GETDATE(), GETDATE(), null, null, 0);



--news
INSERT INTO [ZooManagement].[dbo].[ZooNews] 
    ([Id], [Title], [Description], [Content], [ImageLink], [OwnerId], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsDeleted])
VALUES 
    (NEWID(), N'Cá sấu khổng lồ xuất hiện tại sở thú', N'Tin tức về việc xuất hiện cá sấu lớn trong khu vực sở thú', 
     N'Cá sấu khổng lồ với chiều dài lên đến 5 mét đã xuất hiện tại sở thú. Đây là một sự kiện đặc biệt và thu hút sự chú ý của công chúng.',
     N'https://example.com/image1.jpg', '00000000-0000-0000-0000-000000000000', GETDATE(), GETDATE(), null, null, 0),
    
    (NEWID(), N'Các con sư tử trắng được nuôi dưỡng tốt nhất', N'Thông tin về việc nuôi dưỡng sư tử trắng trong sở thú', 
     N'Các chuyên gia sở thú cho biết rằng việc nuôi dưỡng các con sư tử trắng tại sở thú đã diễn ra tốt đẹp. Các con vật rất khỏe mạnh và phát triển.',
     N'https://example.com/image2.jpg', '00000000-0000-0000-0000-000000000000', GETDATE(), GETDATE(), null, null, 0),
    
    (NEWID(), N'Công việc bảo vệ loài linh cẩu', N'Thông tin về việc bảo vệ loài linh cẩu', 
     N'Sở thú đã tiến hành các hoạt động bảo vệ loài linh cẩu. Điều này giúp duy trì số lượng và môi trường sống của chúng.',
     N'https://example.com/image3.jpg', '00000000-0000-0000-0000-000000000000', GETDATE(), GETDATE(), null, null, 0),
    
    (NEWID(), N'Phát hiện mới về loài khỉ đột tại sở thú', N'Tin tức về phát hiện mới về loài khỉ đột', 
     N'Người quản lý sở thú thông báo về việc phát hiện mới về hành vi và thói quen sinh sống của loài khỉ đột.',
     N'https://example.com/image4.jpg', '00000000-0000-0000-0000-000000000000', GETDATE(), GETDATE(), null, null, 0),
    
    (NEWID(), N'Bí ẩn xung quanh loài gấu trúc', N'Tin tức về loài gấu trúc và bí ẩn xung quanh chúng', 
     N'Các nhà nghiên cứu sở thú tiết lộ về những bí ẩn chưa được giải đáp về loài gấu trúc, góp phần nâng cao hiểu biết về chúng.',
     N'https://example.com/image5.jpg', '00000000-0000-0000-0000-000000000000', GETDATE(), GETDATE(), null, null, 0),
    
    (NEWID(), N'Tiến bộ trong việc bảo tồn voi tại sở thú', N'Tin tức về các tiến bộ trong công tác bảo tồn voi', 
     N'Sở thú đã đạt được nhiều tiến bộ đáng kể trong việc bảo tồn và chăm sóc các con voi. Điều này đã thu hút sự quan tâm lớn từ cộng đồng.',
     N'https://example.com/image6.jpg', '00000000-0000-0000-0000-000000000000', GETDATE(), GETDATE(), null, null, 0),
    
    (NEWID(), N'Cảm xúc của nhân viên sở thú', N'Thông tin về cảm xúc của nhân viên làm việc tại sở thú', 
     N'Nhân viên sở thú chia sẻ về những trải nghiệm và cảm xúc của mình khi làm việc với các loài động vật tại sở thú.',
     N'https://example.com/image7.jpg', '00000000-0000-0000-0000-000000000000', GETDATE(), GETDATE(), null, null, 0),
    
    (NEWID(), N'Hoạt động gần đây của sở thú', N'Tin tức về các hoạt động gần đây của sở thú', 
     N'Sở thú đã tổ chức nhiều hoạt động thú vị và ý nghĩa gần đây, thu hút được sự tham gia của nhiều người dân.',
     N'https://example.com/image8.jpg', '00000000-0000-0000-0000-000000000000', GETDATE(), GETDATE(), null, null, 0),
    
    (NEWID(), N'Câu chuyện về sự sống của loài hươu cao cổ', N'Thông tin về loài hươu cao cổ và sự sống của chúng', 
     N'Câu chuyện về loài hươu cao cổ và cách mà chúng sống, tồn tại trong môi trường tự nhiên.',
     N'https://example.com/image9.jpg', '00000000-0000-0000-0000-000000000000', GETDATE(), GETDATE(), null, null, 0),
    
    (NEWID(), N'Nghiên cứu mới về loài gấu nâu', N'Tin tức về nghiên cứu mới về loài gấu nâu', 
     N'Nhóm nghiên cứu sở thú tiết lộ về các phát hiện mới và những kết quả đáng chú ý trong nghiên cứu về loài gấu nâu.',
     N'https://example.com/image10.jpg', '00000000-0000-0000-0000-000000000000', GETDATE(), GETDATE(), null, null, 0);