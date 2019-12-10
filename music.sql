-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 28 Lis 2019, 19:22
-- Wersja serwera: 10.1.37-MariaDB
-- Wersja PHP: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `music`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `kuba`
--

CREATE TABLE `kuba` (
  `idUser` int(11) NOT NULL,
  `produkt_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `produkty`
--

CREATE TABLE `produkty` (
  `id` int(11) NOT NULL,
  `Tytul` varchar(30) COLLATE utf8_polish_ci NOT NULL,
  `Wykonawca` varchar(30) COLLATE utf8_polish_ci NOT NULL,
  `Gatunek` varchar(20) COLLATE utf8_polish_ci NOT NULL,
  `Cena` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `produkty`
--

INSERT INTO `produkty` (`id`, `Tytul`, `Wykonawca`, `Gatunek`, `Cena`) VALUES
(1, 'Californication', 'Red Hot Chili Peppers', 'rock alternatywny / ', 43.99),
(2, 'The Eminem Show', 'Eminem', 'rap', 37.99),
(3, 'Nevermind', 'Nirvana', 'grunge', 49.99),
(4, 'Random Access Memories', 'Daft Punk', 'funk / disco / muzyk', 19.99),
(5, 'AM', 'Arctic Monkeys', 'indie rock', 34.99),
(6, 'Marmur', 'Taco Hemingway', 'rap', 41.99),
(7, 'Abbey Road', 'The Beatles', 'rock', 61.95),
(8, 'The Dark Side Of The Moon', 'Pink Floyd', 'rock progresywny', 59.99),
(9, 'Hotel California', 'Eagles', 'rock', 32.99),
(10, 'The Attractions Of Youth', 'Barns Courtney', 'indie rock', 49.95),
(11, 'Night Visions', 'Imagine Dragons', 'indie rock', 43.99),
(12, 'Stellar', 'FM Attack', 'muzyka elektroniczna', 25.99),
(13, 'Metallica', 'Metallica', 'heavy metal', 54.99),
(14, 'No Place Is Home', 'Welshly Arms', 'indie rock', 49.89),
(15, 'Love Story', 'Yelawolf', 'rap / country', 49.99),
(16, 'Demon Days', 'Gorillaz', 'house', 19.99),
(17, 'Egzotyka', 'Quebonafide', 'rap', 37.99),
(18, 'The Getaway', 'Red Hot Chili Peppers', 'rock alternatywny / ', 34.99),
(19, 'DAMN.', 'Kendrick Lamar', 'rap', 44.99),
(20, 'In Utero', 'Nirvana', 'grunge', 54.99);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `sale`
--

CREATE TABLE `sale` (
  `idSale` int(11) NOT NULL,
  `idProdukt` int(11) NOT NULL,
  `obnizka` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `sale`
--

INSERT INTO `sale` (`idSale`, `idProdukt`, `obnizka`) VALUES
(2, 9, 2),
(3, 15, 18),
(4, 20, 5.1),
(5, 17, 2),
(8, 1, 1.9),
(10, 3, 0.09),
(13, 4, 1),
(15, 2, 30);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `tymek`
--

CREATE TABLE `tymek` (
  `idUser` int(11) NOT NULL,
  `produkt_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `tymek`
--

INSERT INTO `tymek` (`idUser`, `produkt_id`) VALUES
(1, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `login` varchar(30) COLLATE utf8_polish_ci NOT NULL,
  `password` varchar(30) COLLATE utf8_polish_ci NOT NULL,
  `mail` varchar(40) COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`id`, `login`, `password`, `mail`) VALUES
(1, 'admin', 'admin', 'admin@gmail.com'),
(2, 'Kuba', 'zaq1', 'kuba@wilczak.com'),
(4, 'tymek', 'zaq1', 'tymek@lenart.com');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `kuba`
--
ALTER TABLE `kuba`
  ADD PRIMARY KEY (`idUser`),
  ADD KEY `produkt_id` (`produkt_id`);

--
-- Indeksy dla tabeli `produkty`
--
ALTER TABLE `produkty`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `sale`
--
ALTER TABLE `sale`
  ADD PRIMARY KEY (`idSale`),
  ADD KEY `idProdukt` (`idProdukt`);

--
-- Indeksy dla tabeli `tymek`
--
ALTER TABLE `tymek`
  ADD PRIMARY KEY (`idUser`),
  ADD KEY `produkt_id` (`produkt_id`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `kuba`
--
ALTER TABLE `kuba`
  MODIFY `idUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT dla tabeli `produkty`
--
ALTER TABLE `produkty`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT dla tabeli `sale`
--
ALTER TABLE `sale`
  MODIFY `idSale` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT dla tabeli `tymek`
--
ALTER TABLE `tymek`
  MODIFY `idUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
