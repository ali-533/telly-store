create database tellydb;

use tellydb;

create table Brands (
BrandID int identity(1,1), 
BrandName varchar(60), 
BrandLogo varchar(100), 
primary key(BrandID)
);

create table dimensions(
dimensionID int primary key identity(1,1), 
dimensionNumber int not null
);

--alter table dimensions
--drop column dimensionNumber;

--alter table dimensions
--add size int not null;



create table TVAccessories(
accessoryID int not null identity(1,1), 
accessoryName varchar(50) not null, 
accessoryLength float, 
accessoryImage varchar(100), 
batteryType varchar(100), 
);

alter table TVAccessories
add BrandID int not null;

alter table TVAccessories
add constraint FK_Brands foreign key(BrandID) references Brands(BrandID);

alter table TVAccessories
add constraint PK_TVAccessories primary key(accessoryID);


create table TV(
ID int primary key identity(1,1), 
TVName varchar(200), 
TVType varchar(100), 
TVImageQuality varchar(10), 
FrameFrequency int, 
price float, 
TvURL varchar(100), 
Stars varchar(10), 
BrandID int, 
dimensionID int, 
foreign key(BrandID) references Brands(BrandID), 
foreign key(dimensionID) references dimensions(dimensionID)
);


--alter authorization on database::tellydb to sa;


insert into dimensions(size)
values(32), 
	  (40), 
      (43), 
      (50);



select * from dimensions;



insert into Brands(BrandName)
values('samsung'), ('lg'), ('xiaomi');

select * 
from brands;

--alter table TVAccessories
--alter column BrandID int null;

insert into TVAccessories(accessoryName) 
values ('hdmi');

select * from TVAccessories;

insert into TVAccessories(accessoryName) 
values ('detergent'), ('Universal Remote'), ('LG Remote'), ('Samsung Remote'), 
('Xiaomi Remote');

insert into TVAccessories(accessoryName) 
values('TV supporter');



insert into TV(TVName) 
values
('Samsung QN800D'), 
('Samsung Neo QLED 4k QN90F'),  
('Samsung OLED 4K Smart TV (S90D)'), 
('Samsung Crystal UHD 4K Smart TV (AU7002)'), 
('Samsung Crystal UHD 4K Smart TV (AU7002)'), 
('LG QNED Mini LED QNED90'), 
('LG Micro RGB EVO(MRGB95)'), 
('LG 4k L3321'), 
('Xiaomi x112'),
('Xiaomi x113'),
('Xiaomi x114'),
('Xiaomi x115');



select * 
from TV;





UPDATE TVAccessories SET accessoryImage = 'hdmi.jpg' WHERE accessoryName LIKE '%hdmi%';
UPDATE TVAccessories SET accessoryImage = 'lg remote.jpg' WHERE accessoryName LIKE '%lg%';
UPDATE TVAccessories SET accessoryImage = 'samsung remote.jpg' WHERE accessoryName LIKE '%samsung%';
UPDATE TVAccessories SET accessoryImage = 'universal remote.jpg' WHERE accessoryName LIKE '%universal%';
UPDATE TVAccessories SET accessoryImage = 'tv supporter.jpg' WHERE accessoryName LIKE '%supporter%' OR accessoryName LIKE '%mount%';
UPDATE TVAccessories SET accessoryImage = 'spray cleaner.jpg' WHERE accessoryName LIKE '%cleaner%' OR accessoryName LIKE '%detergent%';
UPDATE TVAccessories SET accessoryImage = 'xiaomi remote.jpg' WHERE accessoryName LIKE '%xiaomi%';
GO




-- 1. SAMSUNG TVs (Assuming BrandID = 1, Dimensions like 55, 65, 75)
UPDATE TV SET TVType = 'Neo QLED', TVImageQuality = '4K UHD', FrameFrequency = 120, price = 1299.99, TvURL = 'samsung-qn90f.jpg', Stars = '5', BrandID = 1, dimensionID = 2 WHERE ID = 1;
UPDATE TV SET TVType = 'Neo QLED', TVImageQuality = '8K UHD', FrameFrequency = 144, price = 2499.99, TvURL = 'samsung-qn90f.jpg', Stars = '5', BrandID = 1, dimensionID = 3 WHERE ID = 2;
UPDATE TV SET TVType = 'OLED', TVImageQuality = '4K UHD', FrameFrequency = 120, price = 1599.99, TvURL = 'samsung-qn90f.jpg', Stars = '4', BrandID = 1, dimensionID = 2 WHERE ID = 3;
UPDATE TV SET TVType = 'Crystal UHD', TVImageQuality = '4K UHD', FrameFrequency = 60, price = 499.99, TvURL = 'samsung-qn90f.jpg', Stars = '4', BrandID = 1, dimensionID = 1 WHERE ID = 4;
UPDATE TV SET TVType = 'Crystal UHD', TVImageQuality = '4K UHD', FrameFrequency = 60, price = 549.99, TvURL = 'samsung-qn90f.jpg', Stars = '4', BrandID = 1, dimensionID = 2 WHERE ID = 5;

-- 2. LG TVs (Assuming BrandID = 2)
UPDATE TV SET TVType = 'Mini LED QNED', TVImageQuality = '4K UHD', FrameFrequency = 120, price = 1199.99, TvURL = 'samsung-qn90f.jpg', Stars = '5', BrandID = 2, dimensionID = 2 WHERE ID = 6;
UPDATE TV SET TVType = 'Micro RGB EVO', TVImageQuality = '8K UHD', FrameFrequency = 144, price = 2299.99, TvURL = 'samsung-qn90f.jpg', Stars = '5', BrandID = 2, dimensionID = 3 WHERE ID = 7;
UPDATE TV SET TVType = 'LED Smart', TVImageQuality = 'FHD', FrameFrequency = 60, price = 349.99, TvURL = 'samsung-qn90f.jpg', Stars = '4', BrandID = 2, dimensionID = 1 WHERE ID = 8;

-- 3. XIAOMI TVs (Assuming BrandID = 3)
UPDATE TV SET TVType = 'Smart LED', TVImageQuality = '4K UHD', FrameFrequency = 60, price = 399.99, TvURL = 'samsung-qn90f.jpg', Stars = '4', BrandID = 3, dimensionID = 1 WHERE ID = 9;
UPDATE TV SET TVType = 'Smart LED', TVImageQuality = '4K UHD', FrameFrequency = 60, price = 449.99, TvURL = 'samsung-qn90f.jpg', Stars = '4', BrandID = 3, dimensionID = 2 WHERE ID = 10;
UPDATE TV SET TVType = 'QLED', TVImageQuality = '4K UHD', FrameFrequency = 120, price = 699.99, TvURL = 'samsung-qn90f.jpg', Stars = '5', BrandID = 3, dimensionID = 2 WHERE ID = 11;
UPDATE TV SET TVType = 'QLED', TVImageQuality = '4K UHD', FrameFrequency = 120, price = 899.99, TvURL = 'samsung-qn90f.jpg', Stars = '5', BrandID = 3, dimensionID = 3 WHERE ID = 12;
GO

select * from TV;

select * from TVAccessories;


-- 1. Update HDMI length
UPDATE TVAccessories 
SET accessoryLength = 0.5 
WHERE accessoryID = 1;



UPDATE TVAccessories 
SET brandID = 4 
WHERE accessoryID = 3;

UPDATE TVAccessories 
SET  BrandID = 1 
WHERE accessoryID = 4;

UPDATE TVAccessories 
SET brandID = 2 
WHERE accessoryID = 5;

UPDATE TVAccessories 
SET brandID = 3 
WHERE accessoryID = 6;


