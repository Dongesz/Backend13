-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Sze 22. 12:09
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
-- Adatbázis: `library`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `books`
--

CREATE TABLE `books` (
  `id` int(11) NOT NULL,
  `title` text NOT NULL,
  `author` text NOT NULL,
  `releaseDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `books`
--

INSERT INTO `books` (`id`, `title`, `author`, `releaseDate`) VALUES
(2, 'Wayward Bus, The', 'Cati Guidi', '2024-09-24'),
(3, 'Marva Collins Story, The', 'Raychel Shaul', '2025-02-21'),
(4, 'Petrified Forest, The', 'Desmond Olsson', '2025-09-10'),
(5, 'Profit, The', 'Romeo Goodacre', '2025-06-20'),
(6, 'Fuzz', 'Roseline Larner', '2025-07-11'),
(7, 'Nightcrawler', 'Lacey Petren', '2025-06-10'),
(8, 'Lady for a Day', 'Ronny Todari', '2025-03-26'),
(9, 'Scarecrow, The', 'Hestia Piotr', '2025-05-09'),
(10, 'Flight Command', 'Gavrielle Cazalet', '2025-08-13'),
(11, 'Vuonna 85', 'Phylis Stebbings', '2025-07-30'),
(12, 'Crazy Thunder Road', 'Fancy Mingotti', '2025-02-15'),
(13, 'Pinocchio', 'Ad MacCambridge', '2025-05-17'),
(14, 'Cold Light of Day, The', 'Hughie Castagnasso', '2025-01-22'),
(15, 'First Sunday', 'Delphinia Hart', '2024-12-19'),
(16, 'Fuzz', 'Orsa Denzilow', '2025-05-12'),
(17, 'The \'High Sign\'', 'Florinda Lembrick', '2025-08-13'),
(18, 'Unknown', 'Orion Mattingson', '2025-07-04'),
(19, 'Swing Time', 'Christyna Carnew', '2025-08-13'),
(20, 'Crossroads', 'Chip Lyness', '2025-06-10'),
(21, 'My Giant', 'Dionne Berrane', '2025-07-04'),
(22, 'Let\'s Make Love', 'Siegfried Pelman', '2024-09-23'),
(23, 'Elena Undone', 'Thurston Sheeres', '2024-10-16'),
(24, 'Spite Marriage', 'Guillema Jimpson', '2025-03-30'),
(25, 'Battling Butler', 'Brett Dearan', '2025-09-03'),
(26, 'Stand-In', 'Alvera Raspel', '2025-08-25'),
(27, 'Another You', 'Padraig Aguirre', '2025-05-25'),
(28, 'Entity', 'Durante Clare', '2025-03-21'),
(29, 'Ferngully: The Last Rainforest', 'Olga Yakhin', '2025-05-24'),
(30, 'Yes Man', 'Ambur Belone', '2024-10-10'),
(31, '52 Pick-Up', 'Rosaline Blaszczyk', '2024-11-02'),
(32, 'Beyond the Lights', 'Reeva Bome', '2025-03-28'),
(33, 'Captain January', 'Cecily Bowmaker', '2025-07-14'),
(34, 'Backstairs (Hintertreppe)', 'Miriam Hillburn', '2024-10-17'),
(35, 'Ghost in the Shell 2: Innocence (a.k.a. Innocence) (Inosensu)', 'Lynn Danilewicz', '2025-05-23'),
(36, 'Phantom of the Opera, The', 'Jacinthe Corley', '2025-03-19'),
(37, 'Emerald Forest, The', 'Pippa Orpen', '2025-06-16'),
(38, 'Bread and Alley (Nan va Koutcheh)', 'Blondelle Linneman', '2024-12-10'),
(39, 'Distant Thunder (Ashani Sanket)', 'Meade Clixby', '2024-11-18'),
(40, 'Never Say Never Again', 'Ysabel Akrigg', '2024-10-29'),
(41, 'Fever', 'Bax Cottage', '2024-12-02'),
(42, 'Grandma\'s Boy', 'Dita Abrashkov', '2024-12-24'),
(43, 'Apple, The (Sib)', 'Billy Probet', '2025-05-29'),
(44, 'Game of Werewolves', 'Carlen Handsheart', '2025-03-27'),
(45, 'Gunfighter, The', 'Felecia Beaver', '2025-06-26'),
(46, 'Covert Action', 'Tresa Bolesma', '2025-07-05'),
(47, 'Saving Sarah Cain', 'Val Ffoulkes', '2024-10-29'),
(48, 'Emperor Jones, The', 'Broddy Cleugher', '2025-03-18'),
(49, 'Sheep Has Five Legs, The (Le mouton à cinq pattes)', 'Addi Mangenot', '2025-06-02'),
(50, 'Killer Elite', 'Dudley Leckenby', '2024-11-09'),
(51, 'Quadrille', 'Petra Borris', '2024-12-18'),
(52, 'Grief', 'Seamus Wolford', '2025-06-07'),
(53, 'American Heist', 'Tiphany Oattes', '2025-08-04'),
(54, 'Late Night Shopping', 'Morgen Hynam', '2025-02-03'),
(55, 'Giorgino', 'Tillie Wesker', '2024-12-01'),
(56, 'Miser, The (L\'avare)', 'Trudey Hudspith', '2024-12-30'),
(57, 'Attack of the Giant Leeches', 'Tait Hesey', '2025-01-06'),
(58, 'One on One', 'Electra Aberdein', '2025-04-28'),
(59, 'Child of Rage', 'Nelie Byrth', '2025-08-09'),
(60, 'The Boy Next Door', 'Shelbi Dufour', '2024-10-07'),
(61, 'They All Laughed', 'Warden Giacubbo', '2025-05-16'),
(62, 'Loner (Woetoli)', 'Ophelia Sibthorp', '2025-08-28'),
(63, 'Girl in the Cadillac', 'Omero Hawthorne', '2024-10-16'),
(64, 'High Society', 'Abagael Fateley', '2025-02-25'),
(65, 'Bionicle: Mask of Light (Bionicle: Mask of Light - The Movie)', 'Wini Masic', '2025-01-31'),
(66, 'Raising Helen', 'Germana Kayne', '2024-11-29'),
(67, 'High Noon', 'Corena Vizard', '2024-10-12'),
(68, 'Princess Aurora (Orora gongju)', 'Rodi Sheddan', '2025-04-16'),
(69, 'Pittsburgh', 'Gregoor Dummett', '2025-01-09'),
(70, 'Mac and Me', 'Tasia Haet', '2024-12-17'),
(71, 'Wild Tales', 'Rana Prene', '2024-10-22'),
(72, 'In Your Dreams (Dans tes rêves)', 'Dalton Thurstance', '2025-03-13'),
(73, 'Dirty Filthy Love', 'Remington Beardsworth', '2024-10-02'),
(74, 'Tokyo Trial (Tokyo saiban)', 'Jamesy Flacknell', '2025-05-18'),
(75, 'Garage Days', 'Shoshanna Glenister', '2025-06-17'),
(76, 'Look Who\'s Talking Now', 'Kary Blundan', '2025-06-26'),
(77, 'Pokrajina St.2', 'Albie Magnus', '2024-09-21'),
(78, 'Fährmann Maria', 'Erminie Eate', '2025-07-23'),
(79, 'Son of God', 'Hube Tansly', '2025-09-03'),
(80, 'Blind Pig Who Wants to Fly (Babi buta yang ingin terbang)', 'Alberto Rowsel', '2025-03-10'),
(81, 'Autobiography of Nicolae Ceausescu, The (Autobiografia lui Nicolae Ceausescu)', 'Lelia Carragher', '2025-01-27'),
(82, 'Executive Suite', 'Joelynn Klain', '2025-05-30'),
(83, 'Vice Squad', 'Duff Gandar', '2025-06-09'),
(84, 'Monster in Paris, A (Un monstre à Paris)', 'Raymond Fritter', '2025-06-26'),
(85, 'Flags of Our Fathers', 'Eustacia Hatherleigh', '2024-11-20'),
(86, 'Outpost', 'Ambur Bogart', '2025-05-16'),
(87, 'Lemonade Joe (Limonádový Joe aneb Konská opera)', 'Luci Thickin', '2024-10-25'),
(88, 'Damned, The (La Caduta degli dei)', 'Marya Kennerley', '2025-03-03'),
(89, 'Blackhat', 'Stillman Holdforth', '2025-03-24'),
(90, 'Loves of a Blonde (Lásky jedné plavovlásky)', 'Oates Tinwell', '2024-12-16'),
(91, 'Chop Shop', 'Orrin Heazel', '2025-03-08'),
(92, 'Faces of Schlock', 'Uriah Oakinfold', '2025-08-29'),
(93, 'Ring of Bright Water', 'Marylin Ingree', '2025-01-20'),
(94, 'Earth Girls Are Easy', 'Ariana Dimitriades', '2025-04-22'),
(95, 'Carrington', 'Leda MacAdam', '2024-12-21'),
(96, 'Spider Baby or, The Maddest Story Ever Told (Spider Baby)', 'Friederike Clerke', '2025-08-22'),
(97, 'Quiet, The', 'Laird Loftus', '2024-09-30'),
(98, 'Perfect Holiday, The', 'Christoffer Strelitzer', '2024-11-26'),
(99, 'My Sister\'s Keeper', 'Ericha Edsall', '2025-08-27'),
(100, 'Shirin', 'Jodi Gaitley', '2025-08-21'),
(105, 'harry potter', 'JKrowling', '2007-10-12'),
(106, 'harry potter', 'JKrowling', '2007-10-12'),
(107, 'harry potter', 'JKrowling', '2007-10-12'),
(108, 'harry potter', 'JKrowling', '2007-10-12');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `cars`
--

CREATE TABLE `cars` (
  `id` int(11) NOT NULL,
  `brand` text NOT NULL,
  `type` text NOT NULL,
  `mDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `cars`
--

INSERT INTO `cars` (`id`, `brand`, `type`, `mDate`) VALUES
(1, 'Mercedes-Benz', 'E-Class', '2024-12-13'),
(2, 'GMC', 'Yukon', '2025-02-20'),
(3, 'Porsche', '911', '2024-09-28'),
(4, 'Ford', 'F-Series', '2024-10-08'),
(6, 'Mazda', '929', '2025-06-26'),
(7, 'Chevrolet', 'Corvette', '2024-10-31'),
(8, 'Dodge', 'Journey', '2024-10-30'),
(9, 'GMC', 'Rally Wagon G2500', '2024-11-07'),
(10, 'Chevrolet', 'Aveo', '2024-12-28'),
(11, 'Mitsubishi', 'Montero Sport', '2025-01-06'),
(12, 'Hyundai', 'Tiburon', '2025-07-05'),
(13, 'GMC', 'Savana 1500', '2025-06-25'),
(14, 'Saab', '9000', '2025-08-08'),
(15, 'Mitsubishi', 'Tredia', '2025-02-11'),
(16, 'Mazda', 'Mazda3', '2025-09-04'),
(17, 'Honda', 'Accord', '2025-04-26'),
(18, 'Mercedes-Benz', '400SEL', '2024-10-23'),
(19, 'Acura', 'RL', '2024-12-06'),
(20, 'Isuzu', 'i-290', '2025-08-31'),
(21, 'Plymouth', 'Neon', '2025-09-21'),
(22, 'Nissan', 'Frontier', '2025-05-16'),
(23, 'Acura', 'MDX', '2025-06-14'),
(24, 'Saturn', 'VUE', '2025-04-06'),
(25, 'Honda', 'Civic Si', '2025-09-07'),
(26, 'Mazda', 'RX-7', '2025-05-21'),
(27, 'Audi', 'S4', '2025-04-21'),
(28, 'Acura', 'Legend', '2025-09-08'),
(29, 'Toyota', 'Matrix', '2025-07-16'),
(30, 'Honda', 'S2000', '2025-04-11'),
(31, 'Toyota', 'Prius', '2025-04-10'),
(32, 'Ford', 'F150', '2025-05-05'),
(33, 'Toyota', 'Celica', '2025-08-02'),
(34, 'Chevrolet', 'Suburban 1500', '2024-12-13'),
(35, 'Buick', 'Hearse', '2024-12-22'),
(36, 'GMC', 'Envoy XL', '2024-12-07'),
(37, 'Dodge', 'Dakota', '2024-10-21'),
(38, 'Jaguar', 'X-Type', '2025-02-05'),
(39, 'Pontiac', 'Firebird', '2025-07-23'),
(40, 'Infiniti', 'M', '2024-12-05'),
(41, 'Mitsubishi', 'i-MiEV', '2025-04-19'),
(42, 'Volkswagen', 'Rabbit', '2024-10-29'),
(43, 'Honda', 'Accord', '2025-07-07'),
(44, 'Bentley', 'Continental GT', '2024-09-28'),
(45, 'Dodge', 'Viper', '2024-09-26'),
(46, 'Ferrari', '612 Scaglietti', '2025-07-15'),
(47, 'Lexus', 'GS', '2025-05-30'),
(48, 'Cadillac', 'SRX', '2024-11-23'),
(49, 'Mazda', 'B-Series Plus', '2024-10-13'),
(50, 'Porsche', 'Boxster', '2025-06-21'),
(51, 'Lexus', 'IS', '2025-02-10'),
(52, 'Pontiac', 'Grand Prix', '2025-06-20'),
(53, 'BMW', 'M6', '2025-04-23'),
(54, 'Lexus', 'LS', '2024-10-18'),
(55, 'Nissan', 'Titan', '2025-07-08'),
(56, 'Oldsmobile', 'LSS', '2025-08-01'),
(57, 'Chevrolet', 'Malibu', '2025-05-30'),
(58, 'Dodge', 'Stratus', '2025-08-22'),
(59, 'Infiniti', 'M', '2024-11-14'),
(60, 'Audi', 'Cabriolet', '2025-02-05'),
(61, 'Ford', 'Escape', '2024-12-18'),
(62, 'Porsche', 'Cayman', '2025-08-26'),
(63, 'Dodge', 'Ram', '2025-02-22'),
(64, 'Acura', 'NSX', '2025-01-21'),
(65, 'GMC', '1500', '2025-02-07'),
(66, 'Toyota', 'Solara', '2025-03-31'),
(67, 'GMC', 'Savana 3500', '2025-05-30'),
(68, 'Pontiac', 'Grand Prix', '2024-09-26'),
(69, 'Pontiac', 'Bonneville', '2024-10-02'),
(70, 'Suzuki', 'Aerio', '2025-05-08'),
(71, 'BMW', '545', '2025-07-15'),
(72, 'BMW', 'M3', '2025-09-06'),
(73, 'Mazda', 'Millenia', '2025-07-18'),
(74, 'Maserati', 'Quattroporte', '2025-04-18'),
(75, 'Audi', 'TT', '2025-06-20'),
(76, 'Mercury', 'Grand Marquis', '2025-06-24'),
(77, 'Mercedes-Benz', 'S-Class', '2025-04-08'),
(78, 'Mazda', '929', '2025-05-10'),
(79, 'Acura', 'TL', '2024-12-03'),
(80, 'Ford', 'Windstar', '2025-09-15'),
(81, 'Nissan', 'Sentra', '2025-03-06'),
(82, 'Volkswagen', 'GTI', '2025-03-10'),
(83, 'Chrysler', 'LHS', '2025-05-13'),
(84, 'Volkswagen', 'Jetta', '2024-12-17'),
(85, 'Honda', 'CR-X', '2025-03-19'),
(86, 'Chevrolet', 'Suburban 1500', '2025-09-14'),
(87, 'Mercury', 'Mariner', '2025-01-23'),
(88, 'Mitsubishi', 'Eclipse', '2024-12-27'),
(89, 'Ford', 'Excursion', '2025-03-30'),
(90, 'Honda', 'Accord', '2025-02-27'),
(91, 'Ford', 'Freestar', '2025-09-18'),
(92, 'Nissan', '350Z', '2025-09-05'),
(93, 'Mitsubishi', 'Pajero', '2025-02-20'),
(94, 'Lotus', 'Esprit', '2025-02-22'),
(95, 'Dodge', 'Dakota', '2024-11-29'),
(96, 'Nissan', 'JUKE', '2025-07-22'),
(97, 'Toyota', 'Tacoma Xtra', '2025-01-04'),
(98, 'BMW', 'M', '2025-02-05'),
(99, 'Nissan', 'Altima', '2025-07-10'),
(100, 'Mercury', 'Grand Marquis', '2025-02-07'),
(101, 'toyota', 'supra', '1999-02-13'),
(102, 'toyota', 'supra mk4', '1999-01-01');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `cars`
--
ALTER TABLE `cars`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `books`
--
ALTER TABLE `books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=109;

--
-- AUTO_INCREMENT a táblához `cars`
--
ALTER TABLE `cars`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=103;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
