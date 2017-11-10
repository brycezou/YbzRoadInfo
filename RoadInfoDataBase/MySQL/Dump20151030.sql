CREATE DATABASE  IF NOT EXISTS `roadsigninfodb_1.0.1` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `roadsigninfodb_1.0.1`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: roadsigninfodb_1.0.1
-- ------------------------------------------------------
-- Server version	5.7.4-m14

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `$请选择线路`
--

DROP TABLE IF EXISTS `$请选择线路`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `$请选择线路` (
  `idnumber` int(11) NOT NULL AUTO_INCREMENT,
  `roadName` varchar(100) NOT NULL,
  `checkTime` varchar(30) NOT NULL,
  `pointNumber` varchar(10) NOT NULL,
  `longitude` varchar(30) NOT NULL,
  `latitude` varchar(30) NOT NULL,
  `leftRight` varchar(5) NOT NULL,
  `markType` varchar(20) NOT NULL,
  `layStyle` varchar(20) NOT NULL,
  `plateStyle` varchar(20) NOT NULL,
  `width` varchar(10) NOT NULL,
  `height` varchar(10) NOT NULL,
  `photoName` varchar(50) NOT NULL,
  `direction` int(11) DEFAULT NULL,
  PRIMARY KEY (`idnumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `$请选择线路`
--

LOCK TABLES `$请选择线路` WRITE;
/*!40000 ALTER TABLE `$请选择线路` DISABLE KEYS */;
/*!40000 ALTER TABLE `$请选择线路` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roadinfotb`
--

DROP TABLE IF EXISTS `roadinfotb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roadinfotb` (
  `roadName` varchar(100) NOT NULL,
  `SP_roadName` varchar(100) DEFAULT NULL,
  `SP_pointNumber` varchar(10) DEFAULT NULL,
  `SP_longitude` varchar(30) DEFAULT NULL,
  `SP_latitude` varchar(30) DEFAULT NULL,
  `EP_roadName` varchar(100) DEFAULT NULL,
  `EP_pointNumber` varchar(10) DEFAULT NULL,
  `EP_longitude` varchar(30) DEFAULT NULL,
  `EP_latitude` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`roadName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roadinfotb`
--

LOCK TABLES `roadinfotb` WRITE;
/*!40000 ALTER TABLE `roadinfotb` DISABLE KEYS */;
INSERT INTO `roadinfotb` VALUES ('$请选择线路',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('test_road_1','kejiyuan','K0.000','118871910','32024681','nanzhan','K0.001',NULL,NULL);
/*!40000 ALTER TABLE `roadinfotb` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `test_road_1`
--

DROP TABLE IF EXISTS `test_road_1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `test_road_1` (
  `idnumber` int(11) NOT NULL AUTO_INCREMENT,
  `roadName` varchar(100) NOT NULL,
  `checkTime` varchar(30) NOT NULL,
  `pointNumber` varchar(10) NOT NULL,
  `longitude` varchar(30) NOT NULL,
  `latitude` varchar(30) NOT NULL,
  `leftRight` varchar(5) NOT NULL,
  `markType` varchar(20) NOT NULL,
  `layStyle` varchar(20) NOT NULL,
  `plateStyle` varchar(20) NOT NULL,
  `width` varchar(10) NOT NULL,
  `height` varchar(10) NOT NULL,
  `photoName` varchar(50) NOT NULL,
  `direction` int(11) DEFAULT NULL,
  PRIMARY KEY (`idnumber`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `test_road_1`
--

LOCK TABLES `test_road_1` WRITE;
/*!40000 ALTER TABLE `test_road_1` DISABLE KEYS */;
INSERT INTO `test_road_1` VALUES (1,' test_road_1','2014/9/4 15:02','K0.000','118871910','32024681','左','A','A','矩形','60','60','11887191032024681_2014940150200.jpg',NULL),(2,' test_road_1','2014/9/4 15:02','K0.000','118871910','32024681','左','A','A','矩形','60','60','11887191032024681_2014940150233.jpg',NULL),(3,' test_road_1','2014/9/4 15:03','K0.146','118871810','32023372','左','A','A','矩形','60','60','11887191032024681_2014940150321.jpg',NULL),(5,' test_road_1','2014/9/4 15:05','K0.146','118871810','32023372','左','A','A','矩形','60','60','11887181032023372_2014940150515.jpg',NULL),(6,' test_road_1','2014/9/4 15:18','K1.137','118871421','32014476','左','A','A','矩形','60','60','11887142132014476_2014940151835.jpg',NULL),(7,' test_road_1','2014/9/4 15:20','K1.331','118871017','32012748','左','A','A','矩形','60','60','11887101732012748_2014940152019.jpg',NULL),(8,' test_road_1','2014/9/4 15:21','K1.394','118871200','32012176','左','A','A','矩形','60','60','11887120032012176_2014940152152.jpg',NULL),(9,' test_road_1','2014/9/4 15:22','K1.398','118870346','32012191','左','A','A','矩形','60','60','11887034632012191_2014940152228.jpg',NULL),(10,' test_road_1','2014/9/4 15:23','K1.407','118869544','32012203','左','A','A','矩形','60','60','11886954432012203_2014940152330.jpg',NULL),(11,' test_road_1','2014/9/4 15:24','K1.423','118866470','32012763','左','A','A','矩形','60','60','11886679032012737_2014940152405.jpg',NULL),(12,' test_road_1','2014/9/4 15:25','K1.486','118864311','32012989','左','A','A','矩形','60','60','11886431132012989_2014940152457.jpg',NULL),(13,' test_road_1','2014/9/4 15:25','K1.477','118864242','32013118','左','A','A','矩形','60','60','11886424232013118_2014940152514.jpg',NULL),(14,' test_road_1','2014/9/4 15:25','K1.487','118864234','32013015','左','A','A','矩形','60','60','11886422732013301_2014940152522.jpg',NULL),(15,' test_road_1','2014/9/4 15:26','K1.480','118863197','32013629','左','A','A','矩形','60','60','11886319732013629_2014940152614.jpg',NULL),(16,' test_road_1','2014/9/4 15:26','K1.501','118863128','32013439','左','A','A','矩形','60','60','11886312832013439_2014940152624.jpg',NULL),(17,' test_road_1','2014/9/4 15:26','K1.518','118862617','32013549','左','A','A','矩形','60','60','11886261732013549_2014940152641.jpg',NULL),(18,' test_road_1','2014/9/4 15:27','K1.518','118862617','32013549','左','A','A','矩形','60','60','11886261732013549_2014940152745.jpg',NULL),(19,' test_road_1','2014/9/4 15:28','K1.508','118862800','32013557','左','A','A','矩形','60','60','11886196132013481_2014940152806.jpg',NULL),(20,' test_road_1','2014/9/4 15:28','K1.483','118863372','32013500','左','A','A','矩形','60','60','11886267032013462_2014940152815.jpg',NULL),(21,' test_road_1','2014/9/4 15:28','K1.522','118862632','32013500','左','A','A','矩形','60','60','11886263232013500_2014940152827.jpg',NULL),(22,' test_road_1','2014/9/4 15:28','K1.498','118863594','32013217','左','A','A','矩形','60','60','11886423432013084_2014940152839.jpg',NULL),(23,' test_road_1','2014/9/4 15:29','K1.410','118869483','32012184','左','A','A','矩形','60','60','11886948332012184_2014940152956.jpg',NULL),(24,' test_road_1','2014/9/4 15:30','K1.409','118869697','32012165','左','A','A','矩形','60','60','11886969732012165_2014940153005.jpg',NULL),(25,' test_road_1','2014/9/4 15:31','K1.397','118870239','32012214','左','A','A','矩形','60','60','11887023932012214_2014940153120.jpg',NULL),(26,' test_road_1','2014/9/4 15:33','K1.418','118871131','32011962','左','A','A','矩形','60','60','11887108632012104_2014940153321.jpg',NULL),(27,' test_road_1','2014/9/4 15:34','K1.402','118871086','32012104','左','A','A','矩形','60','60','11887108632012104_2014940153410.jpg',NULL),(28,' test_road_1','2014/9/4 15:34','K0.383','118871650','32021247','左','A','A','矩形','60','60','11887165032021247_2014940153452.jpg',NULL),(29,' test_road_1','2014/9/4 15:35','K0.016','118871994','32024555','左','A','A','矩形','60','60','11887199432024555_2014940153542.jpg',NULL),(30,' test_road_1','2014/9/4 15:36','K0.094','118871963','32025524','左','A','A','矩形','60','60','11887199432024555_2014940153614.jpg',NULL),(32,' test_road_1','2014/10/29 18:55','K0.930','118862823','32027919','右','B','B','圆形','60','60','11886282332027919_20141029185512.jpg',NULL),(33,' test_road_1','2014/10/30 9:45','K0.403','118874214','32027732','左','A','A','矩形','60','60','11887421432027732_2014103094509.jpg',NULL),(35,' test_road_1','2015/3/25 23:28','K0.657','118868865','32029991','左','A','A','矩形','60','60','11886886532029991_2015325232732.jpg',NULL),(36,' test_road_1','2015/4/10 23:01','K0.699','118868429','32030228','右','A','A','矩形','60','60','11886843332030222_2015410230108.jpg',NULL),(37,' test_road_1','2015/4/10 23:08','K0.693','118868497','32030196','右','A','A','矩形','60','60','11886849732030196_2015410230856.jpg',NULL),(38,' test_road_1','2015/4/10 23:12','K0.680','118868540','32030077','右','A','A','矩形','60','60','11886854032030077_2015410231217.jpg',NULL),(39,' test_road_1','2015/4/10 23:13','K0.665','118868660','32029978','右','A','A','矩形','60','60','11886863432029991_2015410231305.jpg',NULL),(40,' test_road_1','2015/4/10 23:18','K0.645','118868829','32029853','右','A','A','矩形','60','60','11886886432029851_2015410231842.jpg',NULL),(41,' test_road_1','2015/4/10 23:19','K0.659','118868721','32029947','右','A','A','矩形','60','60','11886882932029853_2015410231854.jpg',NULL),(42,' test_road_1','2015/4/10 23:19','K0.664','118868703','32029987','右','A','A','矩形','60','60','11886872132029947_2015410231918.jpg',NULL),(43,' test_road_1','2015/4/10 23:21','K0.691','118868506','32030173','右','A','A','矩形','60','60','11886851232030156_2015410232103.jpg',NULL),(44,' test_road_1','2015/4/10 23:21','K0.694','118868474','32030193','右','A','A','矩形','60','60','11886850632030173_2015410232119.jpg',NULL),(45,' test_road_1','2015/4/10 23:29','K0.663','118868703','32029984','右','A','A','矩形','60','60','',NULL),(46,' test_road_1','2015/4/10 23:30','K0.669','118868656','32030019','右','A','A','矩形','60','60','11886867832030004_2015410233009.jpg',NULL),(47,' test_road_1','2015/4/10 23:30','K0.669','118868656','32030019','右','A','A','矩形','60','60','11886865632030019_2015410233021.jpg',NULL);
/*!40000 ALTER TABLE `test_road_1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'roadsigninfodb_1.0.1'
--

--
-- Dumping routines for database 'roadsigninfodb_1.0.1'
--
/*!50003 DROP PROCEDURE IF EXISTS `AddOneRoad` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddOneRoad`( IN RoadName VARCHAR(100) )
BEGIN
	SET @TMP_NAME = RoadName;
	SET @sql = CONCAT('CREATE TABLE ', @TMP_NAME,
	'(
		idnumber	int				NOT NULL	AUTO_INCREMENT	PRIMARY KEY,
		roadName	varchar(100)	NOT NULL,
		checkTime	varchar(30)		NOT NULL,
		pointNumber varchar(10)		NOT NULL,
		longitude	varchar(30)		NOT NULL,
		latitude	varchar(30)		NOT NULL,
		leftRight	varchar(5)		NOT NULL,
		markType	varchar(20)		NOT NULL,
		layStyle	varchar(20)		NOT NULL,
		plateStyle	varchar(20)		NOT NULL,
		width		varchar(10)		NOT NULL,
		height		varchar(10)		NOT NULL,
		photoName	varchar(50)		NOT NULL,
		direction	int
	)');
	PREPARE stmt FROM @sql;
    EXECUTE stmt;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-10-30 13:58:39
