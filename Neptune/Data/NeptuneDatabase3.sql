CREATE DATABASE  IF NOT EXISTS `neptune` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `neptune`;
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
  `unit` varchar(45) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `added_by` int(11) NOT NULL,
  `date_last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_updated_by` int(11) NOT NULL,
  `deleted` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `adding_worker_material_fk_idx` (`added_by`),
  KEY `last_updating_worker_material_fk_idx` (`last_updated_by`),
  KEY `material_material_category_fk_idx` (`material_category_id`),
  CONSTRAINT `adding_worker_material_fk` FOREIGN KEY (`added_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `last_updating_worker_material_fk` FOREIGN KEY (`last_updated_by`) REFERENCES `workers` (`id`),
  CONSTRAINT `material_material_category_fk` FOREIGN KEY (`material_category_id`) REFERENCES `material_categories` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materials`
--

LOCK TABLES `materials` WRITE;
/*!40000 ALTER TABLE `materials` DISABLE KEYS */;
INSERT INTO `materials` VALUES (1,'TMC 100',11,100.00,'Hook','2018-08-15 08:20:14',1,'2018-08-15 08:20:14',1,0),(2,'Black Thread',12,50.00,'inches','2018-08-15 08:30:04',1,'2018-08-15 08:30:04',1,0),(3,'Golden Pheasant Tippet',8,6.00,'inches','2018-08-15 08:30:04',1,'2018-08-15 08:30:04',1,0),(4,'White Duck Wing Quill',8,34.00,'inches','2018-08-15 08:30:05',1,'2018-08-15 08:30:05',1,0),(5,'Peacock Sword',8,11.00,'inches','2018-08-15 08:30:05',1,'2018-08-15 08:30:05',1,0),(6,'Coachman Brown',10,500.00,'pieces','2018-08-15 08:30:05',1,'2018-08-15 08:30:05',1,0);
/*!40000 ALTER TABLE `materials` ENABLE KEYS */;
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

-- Dump completed on 2018-08-15  8:31:31
