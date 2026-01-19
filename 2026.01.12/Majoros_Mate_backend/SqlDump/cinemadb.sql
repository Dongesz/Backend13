-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Jan 12. 08:31
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `cinemadb`
--
CREATE DATABASE IF NOT EXISTS `cinemadb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `cinemadb`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `actors`
--

CREATE TABLE `actors` (
  `actor_id` int(11) NOT NULL,
  `actor_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `actors`
--

INSERT INTO `actors` (`actor_id`, `actor_name`) VALUES
(1, 'John Doe'),
(2, 'Jane Smith'),
(3, 'Michael Johnson'),
(4, 'Emily Brown'),
(5, 'Daniel Davis'),
(6, 'Sarah Wilson'),
(7, 'Matthew Taylor'),
(8, 'Jessica Martinez'),
(9, 'David Anderson'),
(10, 'Jennifer Thomas'),
(11, 'Christopher Lee'),
(12, 'Amanda White'),
(13, 'Robert Clark'),
(14, 'Melissa Hall'),
(15, 'Kevin Lewis'),
(16, 'Laura Garcia'),
(17, 'James Allen'),
(18, 'Stephanie Young'),
(19, 'William Moore'),
(20, 'Samantha Hernandez'),
(21, 'Joseph King'),
(22, 'Lauren Scott'),
(23, 'Richard Green'),
(24, 'Ashley Adams'),
(25, 'Charles Baker'),
(26, 'Nicole Perez'),
(27, 'Thomas Nelson'),
(28, 'Rebecca Turner'),
(29, 'Ryan Mitchell'),
(30, 'Kimberly Roberts');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `film_type`
--

CREATE TABLE `film_type` (
  `type_id` int(11) NOT NULL,
  `type_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `film_type`
--

INSERT INTO `film_type` (`type_id`, `type_name`) VALUES
(1, 'Action'),
(2, 'Comedy'),
(3, 'Drama'),
(4, 'Sci-Fi'),
(5, 'Horror');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `movies`
--

CREATE TABLE `movies` (
  `movie_id` int(11) NOT NULL,
  `title` varchar(200) NOT NULL,
  `release_date` date NOT NULL,
  `actor_id` int(11) NOT NULL,
  `film_type_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `movies`
--

INSERT INTO `movies` (`movie_id`, `title`, `release_date`, `actor_id`, `film_type_id`) VALUES
(1, 'The Great Adventure', '2023-05-15', 17, 3),
(2, 'Love in Paris', '2022-09-28', 29, 4),
(3, 'Action Hero', '2024-03-10', 12, 1),
(4, 'Romantic Sunset', '2023-12-20', 23, 2),
(5, 'Mystery Mansion', '2024-07-05', 5, 5),
(6, 'Comedy Chaos', '2022-11-18', 8, 1),
(7, 'Thrilling Escape', '2023-08-12', 27, 3),
(8, 'Drama Queen', '2024-02-01', 3, 2),
(9, 'Sci-Fi Odyssey', '2023-10-25', 15, 4),
(10, 'Horror House', '2024-06-08', 2, 5),
(11, 'Adventure Island', '2023-04-17', 19, 1),
(12, 'Paris Romance', '2022-08-09', 10, 4),
(13, 'Action Packed', '2024-01-22', 7, 2),
(14, 'Eternal Love', '2023-11-30', 28, 5),
(15, 'Mysterious Journey', '2024-08-14', 30, 3),
(16, 'Laugh Out Loud', '2022-10-05', 18, 2),
(17, 'Escape Plan', '2023-07-19', 4, 1),
(18, 'Family Drama', '2024-03-03', 21, 4),
(19, 'Space Odyssey', '2023-09-15', 25, 3),
(20, 'Haunted House', '2024-05-28', 1, 5),
(21, 'Treasure Hunt', '2023-03-08', 11, 1),
(22, 'City of Love', '2022-07-01', 24, 2),
(23, 'Ultimate Showdown', '2024-02-14', 20, 5),
(24, 'Epic Romance', '2023-12-10', 14, 3),
(25, 'Enigma', '2024-09-22', 22, 4),
(26, 'Hilarious Hijinks', '2022-11-30', 9, 1),
(27, 'Breakout', '2023-08-05', 6, 4),
(28, 'Life\'s Drama', '2024-01-18', 13, 3),
(29, 'Galactic Adventure', '2023-11-03', 16, 2),
(30, 'House of Horrors', '2024-07-15', 26, 5),
(31, 'Lost in the Jungle', '2023-04-25', 30, 4),
(32, 'A Parisian Affair', '2022-09-10', 5, 1),
(33, 'Battlefield', '2024-03-22', 2, 3),
(34, 'Love Triangle', '2023-12-05', 7, 2),
(35, 'Cryptic Chronicles', '2024-07-20', 19, 5),
(36, 'Funny Fiasco', '2022-10-15', 21, 1),
(37, 'Prison Break', '2023-08-28', 26, 3),
(38, 'Heartfelt Story', '2024-02-08', 8, 2),
(39, 'Space Saga', '2023-10-01', 17, 5),
(40, 'Nightmare', '2024-06-18', 22, 4),
(41, 'Quest for Glory', '2023-05-05', 23, 1),
(42, 'Parisian Nights', '2022-08-20', 14, 3),
(43, 'High-Octane Action', '2024-01-02', 6, 2),
(44, 'Endless Love', '2023-11-15', 12, 5),
(45, 'Journey into Darkness', '2024-08-30', 28, 1),
(46, 'Side-splitting Comedy', '2022-09-03', 25, 4),
(47, 'Escape to Freedom', '2023-07-08', 4, 5),
(48, 'Family Ties', '2024-03-20', 29, 3),
(49, 'Star Odyssey', '2023-09-10', 1, 2),
(50, 'House of Nightmares', '2024-05-25', 9, 1),
(51, 'Pirate Adventure', '2023-03-15', 18, 3),
(52, 'Love in the City', '2022-06-30', 3, 4),
(53, 'Final Showdown', '2024-02-05', 13, 2),
(54, 'Timeless Romance', '2023-12-15', 20, 5),
(55, 'Mystic', '2024-09-28', 7, 1),
(56, 'Crazy Comedy', '2022-11-10', 11, 4),
(57, 'The Great Escape', '2023-08-15', 16, 3),
(58, 'Life\'s Struggles', '2024-01-28', 27, 2),
(59, 'Interstellar Journey', '2023-11-10', 10, 5),
(60, 'Terror in the Dark', '2024-07-30', 24, 1),
(61, 'Batman', '2026-01-12', 2, 4),
(65, 'pokember', '2026-01-12', 6, 3);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `actors`
--
ALTER TABLE `actors`
  ADD PRIMARY KEY (`actor_id`);

--
-- A tábla indexei `film_type`
--
ALTER TABLE `film_type`
  ADD PRIMARY KEY (`type_id`);

--
-- A tábla indexei `movies`
--
ALTER TABLE `movies`
  ADD PRIMARY KEY (`movie_id`),
  ADD KEY `actor_id` (`actor_id`),
  ADD KEY `film_type_id` (`film_type_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `actors`
--
ALTER TABLE `actors`
  MODIFY `actor_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT a táblához `film_type`
--
ALTER TABLE `film_type`
  MODIFY `type_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `movies`
--
ALTER TABLE `movies`
  MODIFY `movie_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `movies`
--
ALTER TABLE `movies`
  ADD CONSTRAINT `movies_ibfk_1` FOREIGN KEY (`actor_id`) REFERENCES `actors` (`actor_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `movies_ibfk_2` FOREIGN KEY (`film_type_id`) REFERENCES `film_type` (`type_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
