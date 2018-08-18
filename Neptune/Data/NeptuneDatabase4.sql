-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: neptune
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `credentials`
--

DROP TABLE IF EXISTS `credentials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `credentials` (
  `id` int(11) NOT NULL,
  `password` varchar(45) NOT NULL,
  `salt` varchar(45) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deactivated` tinyint(3) DEFAULT '0',
  PRIMARY KEY (`id`),
  CONSTRAINT `credential_worker_fk` FOREIGN KEY (`id`) REFERENCES `workers` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credentials`
--

LOCK TABLES `credentials` WRITE;
/*!40000 ALTER TABLE `credentials` DISABLE KEYS */;
INSERT INTO `credentials` VALUES (1,'D6393213228790811FBBD3FD435A054397A3BB4E','294d9ed3-b777-45a3-961b-71681c107d6b','2018-07-25 11:26:52',1,'2018-07-25 11:26:52',1,0);
/*!40000 ALTER TABLE `credentials` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `customers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deleted` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `worker_added_fk_idx` (`added_by`),
  KEY `worker_last_updated_fk_idx` (`last_updated_by`),
  CONSTRAINT `worker_added_fk` FOREIGN KEY (`added_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `worker_last_updated_fk` FOREIGN KEY (`last_updated_by`) REFERENCES `workers` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'Trinity','Page','trinitypage@gmail.com','2018-08-10 21:36:51',1,'2018-08-10 21:36:51',1,0),(2,'Uzair','Hickman','uzairhickman@yahoo.com','2018-08-10 21:44:16',1,'2018-08-10 21:44:16',1,0),(3,'Luka','Goulding','gouldingluka@ymail.com','2018-08-10 21:44:16',1,'2018-08-10 21:44:16',1,0),(4,'Suzie','Cortez','suziecortez@live.com','2018-08-10 21:44:16',1,'2018-08-10 21:44:16',1,0),(5,'Wren','Webber','wrenwebber@outlook.com','2018-08-10 21:44:16',1,'2018-08-10 21:44:16',1,0),(6,'Karis','Bull','karisbull@gmail.com','2018-08-10 21:44:16',1,'2018-08-10 21:44:16',1,0),(7,'Eric','Webb','ericwebb@outlook.com','2018-08-10 21:44:16',1,'2018-08-10 21:44:16',1,0);
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `flies`
--

DROP TABLE IF EXISTS `flies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `flies` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fly_number` varchar(45) NOT NULL,
  `fly` varchar(45) NOT NULL,
  `fly_pattern` int(11) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deleted` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `fly_UNIQUE` (`fly`),
  KEY `adding_worker_fly_fk_idx` (`added_by`),
  KEY `last_updating_worker_fly_fk_idx` (`last_updated_by`),
  CONSTRAINT `adding_worker_fly_fk` FOREIGN KEY (`added_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `fly_pattern_fly_fk` FOREIGN KEY (`id`) REFERENCES `fly_patterns` (`id`),
  CONSTRAINT `last_updating_worker_fly_fk` FOREIGN KEY (`last_updated_by`) REFERENCES `workers` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `flies`
--

LOCK TABLES `flies` WRITE;
/*!40000 ALTER TABLE `flies` DISABLE KEYS */;
INSERT INTO `flies` VALUES (1,'014-206','Royal Coachman Parachute',1,'2018-08-15 13:07:29',1,'2018-08-15 13:07:29',1,0),(2,'041-1312','Black Marabou',8,'2018-08-16 15:14:01',1,'2018-08-16 15:14:01',1,0),(3,'061-1008','Black Wolly Bugger BH',7,'2018-08-16 15:37:38',1,'2018-08-16 15:37:38',1,0);
/*!40000 ALTER TABLE `flies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fly_materials`
--

DROP TABLE IF EXISTS `fly_materials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `fly_materials` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fly_id` int(11) NOT NULL,
  `material_id` int(11) NOT NULL,
  `part` varchar(10) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deleted` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fly_fly_materail_fk_idx` (`fly_id`),
  KEY `material_fly_material_fk_idx` (`material_id`),
  KEY `adding_worker_fly_material_fk_idx` (`added_by`),
  KEY `last_updating_fly_material_worker_idx` (`last_updated_by`),
  CONSTRAINT `adding_worker_fly_material_fk` FOREIGN KEY (`added_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `fly_fly_material_fk` FOREIGN KEY (`fly_id`) REFERENCES `flies` (`id`),
  CONSTRAINT `last_updating_fly_material_worker` FOREIGN KEY (`last_updated_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `material_fly_material_fk` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fly_materials`
--

LOCK TABLES `fly_materials` WRITE;
/*!40000 ALTER TABLE `fly_materials` DISABLE KEYS */;
INSERT INTO `fly_materials` VALUES (1,1,1,'Hook','2018-08-16 16:19:00',1,'2018-08-16 16:19:00',1,0),(2,1,2,'Thread','2018-08-16 16:19:00',1,'2018-08-16 16:19:00',1,0),(3,1,3,'Tail','2018-08-16 16:19:00',1,'2018-08-16 16:19:00',1,0),(4,1,4,'Wing','2018-08-16 16:19:00',1,'2018-08-16 16:19:00',1,0),(5,1,5,'Body','2018-08-16 16:19:00',1,'2018-08-16 16:19:00',1,0),(6,1,7,'Body','2018-08-16 16:19:00',1,'2018-08-16 16:19:00',1,0),(7,1,6,'Hackle','2018-08-16 16:19:00',1,'2018-08-16 16:19:00',1,0),(8,2,3,'Hook','2018-08-16 16:36:09',1,'2018-08-16 16:36:09',1,0),(9,2,2,'Thread','2018-08-16 16:36:09',1,'2018-08-16 16:36:09',1,0),(10,2,16,'Tail','2018-08-16 16:36:09',1,'2018-08-16 16:36:09',1,0),(11,2,17,'Body','2018-08-16 16:36:09',1,'2018-08-16 16:36:09',1,0),(12,2,11,'Wing','2018-08-16 16:36:09',1,'2018-08-16 16:36:09',1,0),(13,2,34,'Wing','2018-08-16 16:36:09',1,'2018-08-16 16:36:09',1,0),(14,2,18,'Collar','2018-08-16 16:36:09',1,'2018-08-16 16:36:09',1,0),(15,2,18,'Head','2018-08-16 16:36:09',1,'2018-08-16 16:36:09',1,0),(16,3,15,'Hook','2018-08-16 16:43:28',1,'2018-08-16 16:43:28',1,0),(17,3,27,'Head','2018-08-16 16:43:28',1,'2018-08-16 16:43:28',1,0),(18,3,28,'Weight','2018-08-16 16:43:28',1,'2018-08-16 16:43:28',1,0),(19,3,29,'Thread','2018-08-16 16:43:28',1,'2018-08-16 16:43:28',1,0),(20,3,11,'Tail','2018-08-16 16:43:28',1,'2018-08-16 16:43:28',1,0),(21,3,30,'Tail','2018-08-16 16:43:28',1,'2018-08-16 16:43:28',1,0),(22,3,31,'Tail','2018-08-16 16:43:28',1,'2018-08-16 16:43:28',1,0),(23,3,32,'Rib','2018-08-16 16:43:28',1,'2018-08-16 16:43:28',1,0),(24,3,14,'Hackle','2018-08-16 16:43:28',1,'2018-08-16 16:43:28',1,0),(25,3,33,'Abdomen','2018-08-16 16:43:28',1,'2018-08-16 16:43:28',1,0);
/*!40000 ALTER TABLE `fly_materials` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fly_patterns`
--

DROP TABLE IF EXISTS `fly_patterns`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `fly_patterns` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fly_pattern` varchar(45) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deleted` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `adding_worker_fly_category_fk_idx` (`added_by`),
  KEY `last_updating_worker_fly_category_fk_idx` (`last_updated_by`),
  CONSTRAINT `adding_worker_fly_category_fk` FOREIGN KEY (`added_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `last_updating_worker_fly_category_fk` FOREIGN KEY (`last_updated_by`) REFERENCES `workers` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fly_patterns`
--

LOCK TABLES `fly_patterns` WRITE;
/*!40000 ALTER TABLE `fly_patterns` DISABLE KEYS */;
INSERT INTO `fly_patterns` VALUES (1,'Dry Flies','2018-08-15 12:34:49',1,'2018-08-15 12:34:49',1,0),(2,'Special Dry','2018-08-15 12:34:49',1,'2018-08-15 12:34:49',1,0),(3,'Wet Flies','2018-08-15 12:34:49',1,'2018-08-15 12:34:49',1,0),(4,'Nymphs','2018-08-15 12:34:49',1,'2018-08-15 12:34:49',1,0),(5,'Tandem','2018-08-15 12:34:49',1,'2018-08-15 12:34:49',1,0),(6,'Streamer','2018-08-15 12:34:49',1,'2018-08-15 12:34:49',1,0),(7,'Wolly Bugger','2018-08-15 12:34:49',1,'2018-08-15 12:34:49',1,0),(8,'Muddler','2018-08-15 12:34:49',1,'2018-08-15 12:34:49',1,0);
/*!40000 ALTER TABLE `fly_patterns` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `material_categories`
--

DROP TABLE IF EXISTS `material_categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `material_categories` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category` varchar(45) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deleted` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `adding_worker_material_category_fk_idx` (`added_by`),
  KEY `last_updating_worker_material_category_fk_idx` (`last_updated_by`),
  CONSTRAINT `adding_worker_material_category_fk` FOREIGN KEY (`added_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `last_updating_worker_material_category_fk` FOREIGN KEY (`last_updated_by`) REFERENCES `workers` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `material_categories`
--

LOCK TABLES `material_categories` WRITE;
/*!40000 ALTER TABLE `material_categories` DISABLE KEYS */;
INSERT INTO `material_categories` VALUES (1,'Synthetic Dubbing','2018-08-15 08:13:04',1,'2018-08-15 08:13:04',1,0),(2,'Natural Dubbing','2018-08-15 08:13:04',1,'2018-08-15 08:13:04',1,0),(3,'Yarn','2018-08-15 08:13:04',1,'2018-08-15 08:13:04',1,0),(4,'Chenille','2018-08-15 08:13:04',1,'2018-08-15 08:13:04',1,0),(5,'Reflectives','2018-08-15 08:13:04',1,'2018-08-15 08:13:04',1,0),(6,'Eyes','2018-08-15 08:13:04',1,'2018-08-15 08:13:04',1,0),(7,'Hair','2018-08-15 08:13:04',1,'2018-08-15 08:13:04',1,0),(8,'Feathers','2018-08-15 08:13:04',1,'2018-08-15 08:13:04',1,0),(9,'Miscellaneous','2018-08-15 08:13:04',1,'2018-08-15 08:13:04',1,0),(10,'Hackle','2018-08-15 08:13:04',1,'2018-08-15 08:13:04',1,0),(11,'Hooks','2018-08-15 08:15:17',1,'2018-08-15 08:15:17',1,0),(12,'Thread','2018-08-15 08:21:39',1,'2018-08-15 08:21:39',1,0);
/*!40000 ALTER TABLE `material_categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materials`
--

DROP TABLE IF EXISTS `materials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `materials` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `material` varchar(45) NOT NULL,
  `material_category_id` int(11) NOT NULL,
  `quantity` decimal(10,2) NOT NULL,
  `depletion_alert_level` decimal(10,2) NOT NULL DEFAULT '10.00',
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deleted` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `material_UNIQUE` (`material`),
  KEY `adding_worker_material_fk_idx` (`added_by`),
  KEY `last_updating_worker_material_fk_idx` (`last_updated_by`),
  KEY `material_material_category_fk_idx` (`material_category_id`),
  CONSTRAINT `adding_worker_material_fk` FOREIGN KEY (`added_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `last_updating_worker_material_fk` FOREIGN KEY (`last_updated_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `material_material_category_fk` FOREIGN KEY (`material_category_id`) REFERENCES `material_categories` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materials`
--

LOCK TABLES `materials` WRITE;
/*!40000 ALTER TABLE `materials` DISABLE KEYS */;
INSERT INTO `materials` VALUES (1,'TMC 100',11,100.00,10.00,'2018-08-15 08:20:14',1,'2018-08-15 08:20:14',1,0),(2,'Black, 6/0',12,100.00,10.00,'2018-08-15 08:30:04',1,'2018-08-15 08:30:04',1,0),(3,'Golden Pheasant Tippet',8,100.00,10.00,'2018-08-15 08:30:04',1,'2018-08-15 08:30:04',1,0),(4,'White Duck Wing Quill',8,100.00,10.00,'2018-08-15 08:30:05',1,'2018-08-15 08:30:05',1,0),(5,'Peacock Sword',8,100.00,10.00,'2018-08-15 08:30:05',1,'2018-08-15 08:30:05',1,0),(6,'Coachman Brown',10,100.00,10.00,'2018-08-15 08:30:05',1,'2018-08-15 08:30:05',1,0),(7,'Red Floss',9,100.00,10.00,'2018-08-15 12:20:37',1,'2018-08-15 12:20:37',1,0),(8,'TMC 300',11,100.00,10.00,'2018-08-15 14:04:35',1,'2018-08-16 15:17:30',1,0),(9,'Black, 8/0',12,100.00,10.00,'2018-08-15 14:04:35',1,'2018-08-15 14:04:35',1,0),(10,'Green Floss',9,100.00,10.00,'2018-08-15 14:04:35',1,'2018-08-15 14:04:35',1,0),(11,'Black Marabou',8,100.00,10.00,'2018-08-15 14:04:35',1,'2018-08-15 14:04:35',1,0),(12,'Silver Wire',5,100.00,10.00,'2018-08-15 14:04:35',1,'2018-08-15 14:04:35',1,0),(13,'Black Chenille',4,100.00,10.00,'2018-08-15 14:04:35',1,'2018-08-15 14:04:35',1,0),(14,'Black Hackle',10,100.00,10.00,'2018-08-15 14:04:35',1,'2018-08-15 14:04:35',1,0),(15,'TMC 5263',11,100.00,10.00,'2018-08-15 14:12:30',1,'2018-08-15 14:12:30',1,0),(16,'Red Hackle',10,100.00,10.00,'2018-08-15 14:12:30',1,'2018-08-15 14:12:30',1,0),(17,'Silver Diamond Braid',9,100.00,10.00,'2018-08-15 14:12:30',1,'2018-08-15 14:12:30',1,0),(18,'Deer Hair',7,100.00,10.00,'2018-08-15 14:12:30',1,'2018-08-16 15:22:45',1,0),(27,'Gold Bead, Medium',9,100.00,10.00,'2018-08-16 15:34:38',1,'2018-08-16 15:34:38',1,0),(28,'Lead Wire',5,100.00,10.00,'2018-08-16 15:34:39',1,'2018-08-16 15:34:39',1,0),(29,'Black, 3/0',12,100.00,10.00,'2018-08-16 15:34:39',1,'2018-08-16 15:34:39',1,0),(30,'Pearl Krystal Flash',5,100.00,10.00,'2018-08-16 15:34:39',1,'2018-08-16 15:34:39',1,0),(31,'Red Krystal Flash',5,100.00,10.00,'2018-08-16 15:34:39',1,'2018-08-16 15:34:39',1,0),(32,'Copper Wire, Small',5,100.00,10.00,'2018-08-16 15:34:39',1,'2018-08-16 15:34:39',1,0),(33,'Peacock Herl',8,100.00,10.00,'2018-08-16 15:34:39',1,'2018-08-16 15:34:39',1,0),(34,'Black Calf Body',7,100.00,10.00,'2018-08-16 16:33:04',1,'2018-08-16 16:33:04',1,0),(35,'Antron',1,100.00,10.00,'2018-08-16 18:12:21',1,'2018-08-16 18:12:21',1,0),(36,'CDC Dubbing',2,100.00,10.00,'2018-08-16 19:59:28',1,'2018-08-16 19:59:28',1,0),(37,'Fuzzy Wool',3,100.00,10.00,'2018-08-16 20:00:48',1,'2018-08-16 20:00:48',1,0),(38,'Prismatic Eyes',6,100.00,10.00,'2018-08-16 20:01:59',1,'2018-08-16 20:01:59',1,0);
/*!40000 ALTER TABLE `materials` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_items`
--

DROP TABLE IF EXISTS `order_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `order_items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) NOT NULL,
  `fly_id` int(11) NOT NULL,
  `dozens` decimal(10,2) NOT NULL,
  `is_complete` tinyint(4) NOT NULL DEFAULT '0',
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deleted` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `order_order_item_fk_idx` (`order_id`),
  KEY `fly_order_item_fk_idx` (`fly_id`),
  KEY `adding_worker_order_item_fk_idx` (`added_by`),
  KEY `last_updateing_worker_order_item_idx` (`last_updated_by`),
  CONSTRAINT `adding_worker_order_item_fk` FOREIGN KEY (`added_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `fly_order_item_fk` FOREIGN KEY (`fly_id`) REFERENCES `flies` (`id`),
  CONSTRAINT `last_updateing_worker_order_item` FOREIGN KEY (`last_updated_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `order_order_item_fk` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_items`
--

LOCK TABLES `order_items` WRITE;
/*!40000 ALTER TABLE `order_items` DISABLE KEYS */;
INSERT INTO `order_items` VALUES (1,1,1,10.00,0,'2018-08-16 16:55:08',1,'2018-08-16 16:56:08',1,0),(2,1,3,15.00,0,'2018-08-16 16:56:39',1,'2018-08-16 16:56:39',1,0),(3,2,2,10.00,0,'2018-08-16 16:58:02',1,'2018-08-16 16:58:02',1,0),(4,3,1,10.00,0,'2018-08-16 16:58:26',1,'2018-08-16 16:58:26',1,0);
/*!40000 ALTER TABLE `order_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deleted` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `customer_order_fk_idx` (`customer_id`),
  KEY `adding_worker_fk_idx` (`added_by`),
  KEY `last_updating_worker_fk_idx` (`last_updated_by`),
  KEY `customer_order_id_fk_idx` (`customer_id`),
  KEY `adding_worker_order_fk_idx` (`added_by`),
  KEY `last_updating_worker_order_fk_idx` (`last_updated_by`),
  CONSTRAINT `adding_worker_order_fk` FOREIGN KEY (`added_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `customer_order_id_fk` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`id`),
  CONSTRAINT `last_updating_worker_order_fk` FOREIGN KEY (`last_updated_by`) REFERENCES `workers` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,1,'2018-08-13 20:59:59',1,'2018-08-13 20:59:59',1,0),(2,3,'2018-08-13 20:59:59',1,'2018-08-13 20:59:59',1,0),(3,6,'2018-08-13 20:59:59',1,'2018-08-13 20:59:59',1,0),(4,2,'2018-08-13 20:59:59',1,'2018-08-13 20:59:59',1,0),(5,7,'2018-08-13 20:59:59',1,'2018-08-13 20:59:59',1,0);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `positions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `position` varchar(45) NOT NULL,
  `salary` varchar(45) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
INSERT INTO `positions` VALUES (1,'Director','60000','2018-07-25 09:46:03',1,'2018-07-25 09:46:03',1),(2,'Manager','55000','2018-08-02 16:00:25',1,'2018-08-02 16:00:25',1),(3,'Supervisor','50000','2018-08-02 16:08:37',1,'2018-08-02 16:08:37',1),(4,'Quality Assurance','45000','2018-08-02 16:08:38',1,'2018-08-02 16:08:38',1),(5,'Packer','40000','2018-08-02 16:08:38',1,'2018-08-02 16:08:38',1),(6,'Store Keeper','35000','2018-08-02 16:08:38',1,'2018-08-02 16:08:38',1),(7,'Tier','1','2018-08-02 16:08:38',1,'2018-08-02 16:08:38',1);
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workers`
--

DROP TABLE IF EXISTS `workers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `workers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(15) NOT NULL,
  `last_name` varchar(15) NOT NULL,
  `phone_number` varchar(13) NOT NULL,
  `position_id` int(11) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deleted` tinyint(3) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `workers_position_fk_idx` (`position_id`),
  KEY `adding_worker_fk_idx` (`added_by`),
  CONSTRAINT `adding_worker_fk` FOREIGN KEY (`added_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `workers_position_fk` FOREIGN KEY (`position_id`) REFERENCES `positions` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workers`
--

LOCK TABLES `workers` WRITE;
/*!40000 ALTER TABLE `workers` DISABLE KEYS */;
INSERT INTO `workers` VALUES (1,'Phoebe','Kay','0712378476',1,'2018-07-25 09:43:04',1,'2018-07-25 09:43:04',1,0),(2,'Daisy','Toggy','0734765478',1,'2018-07-25 09:47:44',1,'2018-07-25 09:47:44',1,0),(3,'Jane','Main','0722543785',2,'2018-08-02 17:15:58',1,'2018-08-02 17:15:58',1,0);
/*!40000 ALTER TABLE `workers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'neptune'
--

--
-- Dumping routines for database 'neptune'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-18  9:25:20
