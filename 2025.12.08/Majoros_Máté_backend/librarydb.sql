-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Jan 05. 10:47
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
-- Adatbázis: `librarydb`
--
CREATE DATABASE IF NOT EXISTS `librarydb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `librarydb`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `authors`
--

CREATE TABLE `authors` (
  `author_id` int(11) NOT NULL,
  `author_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `authors`
--

INSERT INTO `authors` (`author_id`, `author_name`) VALUES
(1, 'John Smith'),
(2, 'Mary Johnson'),
(3, 'Michael Williams'),
(4, 'Jennifer Brown'),
(5, 'William Jones'),
(6, 'Patricia Davis'),
(7, 'David Miller'),
(8, 'Linda Wilson'),
(9, 'Richard Moore'),
(10, 'Elizabeth Taylor'),
(11, 'Charles Anderson'),
(12, 'Barbara Thomas'),
(13, 'Joseph Jackson'),
(14, 'Jessica White'),
(15, 'Thomas Harris');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `books`
--

CREATE TABLE `books` (
  `book_id` int(11) NOT NULL,
  `title` varchar(200) NOT NULL,
  `publish_date` date NOT NULL,
  `author_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `books`
--

INSERT INTO `books` (`book_id`, `title`, `publish_date`, `author_id`, `category_id`) VALUES
(1, 'The Great Gatsby', '1925-04-10', 10, 1),
(2, 'To Kill a Mockingbird', '1960-07-11', 8, 1),
(3, '1984', '1949-06-08', 12, 2),
(4, 'Pride and Prejudice', '1813-01-28', 5, 3),
(5, 'Harry Potter and the Philosopher\'s Stone', '1997-06-26', 2, 4),
(6, 'The Catcher in the Rye', '1951-07-16', 15, 1),
(7, 'The Hobbit', '1937-09-21', 7, 4),
(8, 'Animal Farm', '1945-08-17', 1, 2),
(9, 'Lord of the Flies', '1954-09-17', 6, 5),
(10, 'The Da Vinci Code', '2003-03-18', 11, 5),
(11, 'Jane Eyre', '1847-10-16', 3, 3),
(12, 'The Lord of the Rings', '1954-07-29', 14, 4),
(13, 'The Alchemist', '1988-01-01', 13, 5),
(14, 'A Tale of Two Cities', '1859-04-30', 4, 1),
(15, 'Wuthering Heights', '1847-12-29', 9, 3),
(16, 'Brave New World', '1932-10-27', 10, 2),
(17, 'The Adventures of Huckleberry Finn', '1884-12-10', 13, 5),
(18, 'The Secret Garden', '1911-08-16', 15, 1),
(19, 'Crime and Punishment', '1866-11-14', 8, 5),
(20, 'One Hundred Years of Solitude', '1967-05-30', 3, 2),
(21, 'The Odyssey', '1967-05-28', 12, 4),
(22, 'Frankenstein', '1818-01-01', 6, 3),
(23, 'Dracula', '1897-05-26', 14, 3),
(24, 'The Road', '2006-09-26', 2, 4),
(25, 'The Kite Runner', '2003-05-29', 5, 5),
(26, 'The Picture of Dorian Gray', '1890-07-20', 11, 1),
(27, 'The Hitchhiker\'s Guide to the Galaxy', '1979-10-12', 9, 1),
(28, 'Gone with the Wind', '1936-06-30', 7, 3),
(29, 'Moby-Dick', '1851-10-18', 1, 4),
(30, 'The Chronicles of Narnia: The Lion, the Witch and the Wardrobe', '1950-10-16', 4, 4),
(31, 'hp', '2026-01-05', 1, 2),
(32, 'ht', '2026-01-05', 4, 1),
(34, 'asd', '2026-01-05', 4, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `categories`
--

CREATE TABLE `categories` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `categories`
--

INSERT INTO `categories` (`category_id`, `category_name`) VALUES
(1, 'Electronics'),
(2, 'Clothing'),
(3, 'Books'),
(4, 'Home & Garden'),
(5, 'Sports');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`author_id`);

--
-- A tábla indexei `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`book_id`),
  ADD KEY `author_id` (`author_id`),
  ADD KEY `category_id` (`category_id`);

--
-- A tábla indexei `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `authors`
--
ALTER TABLE `authors`
  MODIFY `author_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT a táblához `books`
--
ALTER TABLE `books`
  MODIFY `book_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT a táblához `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `books`
--
ALTER TABLE `books`
  ADD CONSTRAINT `books_ibfk_2` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`),
  ADD CONSTRAINT `books_ibfk_3` FOREIGN KEY (`author_id`) REFERENCES `authors` (`author_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
