-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 17, 2021 at 06:38 PM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.0.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_antibody_unbranded`
--

-- --------------------------------------------------------

--
-- Table structure for table `uservideoprogress`
--

CREATE TABLE `uservideoprogress` (
  `VideoProgressId` int(11) NOT NULL,
  `UserGuid` varchar(64) NOT NULL,
  `VideoId` int(11) DEFAULT NULL,
  `ProgressSecond` decimal(10,2) NOT NULL,
  `Misc` mediumtext DEFAULT NULL,
  `DateUpdated` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `uservideoprogress`
--

INSERT INTO `uservideoprogress` (`VideoProgressId`, `UserGuid`, `VideoId`, `ProgressSecond`, `Misc`, `DateUpdated`) VALUES
(1, 'e9fadba2-e2ff-8f92-8707-cfbcb13aeb4f', 1, '113.00', NULL, '2021-10-04 21:59:40');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `uservideoprogress`
--
ALTER TABLE `uservideoprogress`
  ADD PRIMARY KEY (`VideoProgressId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `uservideoprogress`
--
ALTER TABLE `uservideoprogress`
  MODIFY `VideoProgressId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
