create table Product
(
	ProductID int identity(1,1),
	ProductName nvarchar(50),
	Details nvarchar(1000),
	Price int default 0 not null,
	Constraint PK_Product primary key(ProductID)
)

create table [Type]
(
	TypeID int,
	TypeName nvarchar(50),
	Constraint PK_Type primary key(TypeID)
)

create table ProductTypes
(
	ProductID int,
	TypeID int,
	constraint pk_ProductTypes primary key(ProductID, TypeID),
	constraint fk_ProductTypes_Product foreign key(ProductID) references Product(ProductID),
	constraint fk_ProductTypes_Type foreign key(TypeID) references [Type](TypeID)
)

create table Stock
(
	ProductID int,
	InitialQuantity int default(0) not null,
	SoldQuantity int default(0) not null,
	constraint pk_Stock primary key(ProductID),
	constraint fk_Stock_Product foreign key(ProductID) references Product(ProductID)
)

create table UserProfile
(
	UserID int identity(1, 1),
	Username nvarchar(50) not null UNIQUE,
	[Password] nvarchar(MAX) not null,
	Salt int not null,
	constraint PK_UserProfile primary key(UserID)
)
alter table UserProfile add LoginToken uniqueidentifier 

create table Cart
(
	UserID int,
	ProductID int,
	Quantity int not null default 0,
	Constraint PK_Cart primary key (UserID, ProductID),
	constraint FK_Cart_UserProfile foreign key(UserID) references UserProfile(UserID),
	Constraint FK_Cart_Product foreign key(ProductID) references Product(ProductID)
)

insert into Product values('Screwdriver', 'Red', 11), ('Pillow', 'Goose feathers', 55), ('Pickhammer', 'Medieval!', 999), ('Golf clujb', 'Bent', 60), ('Jade warrior', 'Cracked', 7), ('Fur coat', 'Hair falling off', 70), ('Drawer', 'Rotting', 23)
