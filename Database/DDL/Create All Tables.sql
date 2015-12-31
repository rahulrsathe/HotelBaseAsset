delimiter $$

CREATE TABLE `billdetail` (
  `BillID` int(11) NOT NULL AUTO_INCREMENT,
  `BillNumber` int(11) NOT NULL,
  `TaxAmt` decimal(10,0) DEFAULT NULL,
  `BillAmt` decimal(10,0) DEFAULT NULL,
  `BillDate` datetime DEFAULT NULL,
  `PaymentType` varchar(4) DEFAULT NULL,
  `Notes10` int(11) DEFAULT NULL,
  `Notes20` int(11) DEFAULT NULL,
  `Notes50` int(11) DEFAULT NULL,
  `Notes100` int(11) DEFAULT NULL,
  `Notes500` int(11) DEFAULT NULL,
  `Notes1000` int(11) DEFAULT NULL,
  `BillStatus` varchar(4) DEFAULT NULL,
  `CustID` int(11) DEFAULT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`BillID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `codecategory` (
  `CategoryID` int(11) NOT NULL AUTO_INCREMENT,
  `CatDesc` varchar(45) DEFAULT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  `CatCode` varchar(8) NOT NULL,
  PRIMARY KEY (`CategoryID`),
  UNIQUE KEY `CatCode_UNIQUE` (`CatCode`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `codedecode` (
  `CodeID` int(11) NOT NULL AUTO_INCREMENT,
  `CatID` int(11) NOT NULL,
  `Code` varchar(8) NOT NULL,
  `CodeDesc` varchar(45) NOT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodeID`),
  KEY `CodeToCat1` (`CatID`),
  CONSTRAINT `CodeToCat1` FOREIGN KEY (`CatID`) REFERENCES `codecategory` (`CategoryID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `customerdetail` (
  `CustomerID` int(11) NOT NULL AUTO_INCREMENT,
  `Fname` varchar(45) DEFAULT NULL,
  `Lname` varchar(45) NOT NULL,
  `PhoneNum` varchar(20) NOT NULL,
  `Addr1` varchar(45) NOT NULL,
  `Addr2` varchar(45) NOT NULL,
  `Addr3` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `State` varchar(20) DEFAULT NULL,
  `Pin` varchar(10) DEFAULT NULL,
  `Status` varchar(4) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`CustomerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `finedinetables` (
  `FineDineTableID` int(11) NOT NULL AUTO_INCREMENT,
  `TableNickName` varchar(45) NOT NULL,
  `HotelID` int(11) NOT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`FineDineTableID`),
  KEY `ToHotel` (`HotelID`),
  CONSTRAINT `ToHotel` FOREIGN KEY (`HotelID`) REFERENCES `hoteldetail` (`hotelid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `foodorderdetail` (
  `FoodOrderDetailID` int(11) NOT NULL AUTO_INCREMENT,
  `OrderID` int(11) NOT NULL,
  `MenuItemID` int(11) NOT NULL,
  `MenuItemQty` int(11) DEFAULT NULL,
  `TaxID` int(11) DEFAULT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`FoodOrderDetailID`),
  KEY `OrderDetailToHeader` (`OrderID`),
  CONSTRAINT `OrderDetailToHeader` FOREIGN KEY (`OrderID`) REFERENCES `foodorderheader` (`OrderID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=98 DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `foodorderheader` (
  `OrderID` int(11) NOT NULL AUTO_INCREMENT,
  `OrderNumber` int(11) NOT NULL,
  `TableID` int(11) NOT NULL,
  `OrderStartTime` datetime DEFAULT NULL,
  `OrderEndTime` datetime DEFAULT NULL,
  `OrderStatus` char(4) NOT NULL,
  `BillID` int(11) DEFAULT NULL,
  `OrderType` char(4) NOT NULL,
  `CustomerID` int(11) DEFAULT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`OrderID`),
  KEY `OrderHToFineDineTables` (`TableID`),
  KEY `OrderHToBill` (`BillID`),
  KEY `OrderIDToCust` (`CustomerID`),
  CONSTRAINT `OrderHToBill` FOREIGN KEY (`BillID`) REFERENCES `billdetail` (`BillID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `OrderIDToCust` FOREIGN KEY (`CustomerID`) REFERENCES `customerdetail` (`CustomerID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `hoteldetail` (
  `hotelid` int(11) NOT NULL AUTO_INCREMENT,
  `HotelName` varchar(45) DEFAULT NULL,
  `HotelAddr1` varchar(45) DEFAULT NULL,
  `sHotelAddr2` varchar(45) DEFAULT NULL,
  `HotelAddr3` varchar(45) DEFAULT NULL,
  `HotelState` varchar(20) NOT NULL,
  `HotelPin` varchar(45) NOT NULL,
  `HotelLogo` blob,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` varchar(16) DEFAULT NULL,
  `HotelPhone` varchar(20) DEFAULT NULL,
  `HotelContact` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`hotelid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `inventorydetail` (
  `InventoryDetailID` int(11) NOT NULL AUTO_INCREMENT,
  `InventoryTypeID` int(11) NOT NULL,
  `InventoryQty` int(11) NOT NULL,
  `InventoryAction` varchar(4) NOT NULL,
  `InventoryCost` decimal(10,0) NOT NULL,
  `BoughtUsedDate` datetime DEFAULT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`InventoryDetailID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `inventoryheader` (
  `InventoryHeaderid` int(11) NOT NULL AUTO_INCREMENT,
  `InventoryTypeID` int(11) NOT NULL,
  `InventoryTypeName` varchar(45) NOT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`InventoryHeaderid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `menuitemheader` (
  `MenuItemID` int(11) NOT NULL AUTO_INCREMENT,
  `MenuItemType` varchar(4) NOT NULL,
  `MenuItemName` varchar(45) NOT NULL,
  `MenuItemCost` decimal(10,0) NOT NULL,
  `ReduceInventoryID` int(11) DEFAULT NULL,
  `ReduceInventoryBy` int(11) DEFAULT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  `TaxID` int(11) NOT NULL,
  `HotelID` int(11) NOT NULL,
  PRIMARY KEY (`MenuItemID`),
  KEY `ToHotelID1` (`HotelID`),
  CONSTRAINT `ToHotelID1` FOREIGN KEY (`HotelID`) REFERENCES `hoteldetail` (`hotelid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `menutax` (
  `MenuTaxID` int(11) NOT NULL AUTO_INCREMENT,
  `TaxPercent` decimal(19,3) NOT NULL,
  `DelFlag` char(1) DEFAULT NULL,
  `ModDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModBy` int(11) DEFAULT NULL,
  `HotelID` int(11) NOT NULL,
  PRIMARY KEY (`MenuTaxID`),
  KEY `ToHotelID2` (`HotelID`),
  CONSTRAINT `ToHotelID2` FOREIGN KEY (`HotelID`) REFERENCES `hoteldetail` (`hotelid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `role_detail` (
  `role_id` int(11) NOT NULL AUTO_INCREMENT,
  `role_desc` varchar(45) NOT NULL,
  `lastupdate` datetime DEFAULT NULL,
  `updateby` varchar(45) DEFAULT NULL,
  `status` char(1) DEFAULT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `role_page_access` (
  `page_name` varchar(50) NOT NULL,
  `role_id` int(11) NOT NULL,
  `has_access` varchar(1) NOT NULL,
  `status` char(1) DEFAULT NULL,
  `lastupdate` datetime DEFAULT NULL,
  `updateby` int(11) DEFAULT NULL,
  KEY `RolePageToUsers` (`role_id`),
  CONSTRAINT `RolePageToUsers` FOREIGN KEY (`role_id`) REFERENCES `role_detail` (`role_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8$$


delimiter $$

CREATE TABLE `users` (
  `employee_id` int(11) NOT NULL,
  `login_name` varchar(45) NOT NULL,
  `sys_pwd` varchar(45) NOT NULL,
  `lname` varchar(45) NOT NULL,
  `fname` varchar(45) NOT NULL,
  `role_id` int(11) NOT NULL,
  `phone_no` varchar(45) DEFAULT NULL,
  `mobile_no` varchar(45) DEFAULT NULL,
  `addr1` varchar(45) DEFAULT NULL,
  `addr2` varchar(45) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `state` varchar(45) DEFAULT NULL,
  `pin` varchar(45) DEFAULT NULL,
  `lastupdate` varchar(45) DEFAULT NULL,
  `updateby` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `delflag` varchar(45) DEFAULT NULL,
  `hotelid` int(11) DEFAULT NULL,
  PRIMARY KEY (`employee_id`),
  KEY `UsersToHotel1` (`hotelid`),
  CONSTRAINT `UsersToHotel1` FOREIGN KEY (`hotelid`) REFERENCES `hoteldetail` (`hotelid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8$$


