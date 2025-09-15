-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Sze 15. 11:14
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
(1, 'Opfergang', 'Pammy Tidbury', '2025-05-18'),
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
(100, 'Shirin', 'Jodi Gaitley', '2025-08-21');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `books`
--
ALTER TABLE `books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
