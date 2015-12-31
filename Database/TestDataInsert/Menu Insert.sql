delete from foodorderdetail;
delete from billdetail;
delete from foodorderheader;
delete from foodordertax;
delete from menutax;
delete from menuitemheader;
delete from codedecode where catid=4;
delete from menutax;
insert into menutax values (1,12.5,'N',now(),now(),'1',1,'VAT','VAT');



INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('7','VOID','Voided','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','SPLT','Speciality','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','RICE','Rice','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','ROTI','Roti','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','SDSH','Side Dish','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','DSRT','Dessert','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','FHFY','Fish Fry','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','MSLA','Masala','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','CURY','Curry','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','VEG','Veg','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','THLI','Thali','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','KADI','Kadi','N',now(),now(),1);
INSERT INTO codedecode  ( `CatID`, `Code`, `CodeDesc`, `DelFlag`, `ModDate`, `CreateDate`, `ModBy`) VALUES ('4','SOUP','Soup','N',now(),now(),1);


INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'SPLT','Stuff Pomphret',450,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'SPLT','Fish Platter',1200,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'RICE','Steam Rice',80,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'RICE','Prawns Rice',200,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'RICE','Surmai Rice',200,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'RICE','Pomphret Rice',200,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'RICE','Egg Rice',130,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'RICE','Chicken Rice',160,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'RICE','Mutton Rice',220,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'ROTI','Bhakari',15,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'ROTI','Chapati',8,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'SDSH','Masala Papad',25,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'SDSH','Roasted Papad',10,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'SDSH','Fried Papad',15,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'SDSH','Green Salad',40,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'DSRT','Gulab jamun',40,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'DSRT','Soft Drink',25,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'DSRT','Water',25,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Surmai Fry',170,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Bangada Fry',170,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Halwa Fry',170,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Rawas Fry',190,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Ghol Fry',190,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Bombil Fry',120,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Mandeli Fry',150,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Pomphret Fry',190,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Prawns Fry',190,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Butter Garlic Prawns',300,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Jumbo Pomphret Fry',300,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','King Prawns Fry',300,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Jumbo Surmai Fry',300,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'FHFY','Jitada Fry',300,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Prawns Masala',170,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Karandi Masala',170,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Jawala Masala',100,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Sukha Bombil',130,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Khekda Masala',170,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Tisrya Masala',170,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Chicken Masala',150,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Chicken Sukha',160,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Mutton Masala',190,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Mutton Sukha',190,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'MSLA','Egg Masala',100,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'CURY','Surmai Curry',180,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'CURY','Bangada Curry',180,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'CURY','Halwa Curry',180,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'CURY','Bombil Curry',160,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'CURY','Pomphret Curry',200,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'CURY','Prawns Curry',200,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'CURY','Rawas Curry',200,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'CURY','Ghol Curry',200,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'CURY','Jitada Curry',400,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'VEG','Veg bhaji',80,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Surmai',210,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Bangada',210,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Halwa',210,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Bombil',190,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Pomphret',230,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Prawns',230,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Karandi ',230,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Rawas',230,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Khekada',230,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Tisrya',230,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Chicken',210,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Mutton ',240,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Egg',140,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'THLI','Veg',130,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'KADI','Solkadi',25,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'KADI','Fresh Lime Juice',20,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'KADI','Fresh Lime Soda',40,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'SOUP','Tomato Soup',70,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'SOUP','Prawns Soup',80,1,1,'N',1,1);
INSERT INTO `hotelbase`.`menuitemheader`
( 
`MenuItemType`,
`MenuItemName`,
`MenuItemCost`,
`ReduceInventoryID`,
`ReduceInventoryBy`,
`DelFlag`,`TaxID`,`HotelID`  )
VALUES
( 'SOUP','Chicken Soup',80,1,1,'N',1,1);

INSERT INTO foodorderheader (orderid,ordernumber,tableid,orderstarttime,orderendtime,orderstatus,ordertype) values(1,1,1,now(),now(),5,6) ;
insert into billdetail (billid,billnumber,orderid)values (1,1,1);