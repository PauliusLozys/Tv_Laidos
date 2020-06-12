-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 2020 m. Geg 27 d. 11:57
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tv_laidos_db`
--

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `aktorius`
--

CREATE TABLE `aktorius` (
  `vardas` varchar(50) NOT NULL,
  `pavarde` varchar(50) NOT NULL,
  `gimimo_metai` date NOT NULL,
  `lytis` int(11) NOT NULL,
  `id_AKTORIUS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `aktorius`
--

INSERT INTO `aktorius` (`vardas`, `pavarde`, `gimimo_metai`, `lytis`, `id_AKTORIUS`) VALUES
('Tom', 'Hanks', '1956-07-09', 1, 1),
('Stella', 'Maeve', '1989-11-14', 2, 2),
('Hale', 'Appleman', '1986-02-17', 1, 3),
('Arjun', 'Gupta', '1986-11-28', 1, 4),
('Summer', 'Bishil', '1988-07-17', 2, 5),
('Olivia', 'Dudley', '1985-11-04', 2, 6),
('Jason', 'Ralph', '1986-04-07', 1, 7),
('Jade', 'Tailor', '1985-08-12', 2, 8),
('Brittany', 'Curran', '1990-09-02', 2, 9),
('Rick', 'Worthy', '1967-04-12', 1, 10),
('Trevor', 'Einhorn', '1988-11-03', 1, 11),
('Chris', 'Conner', '1975-03-04', 1, 12),
('Anthony', 'Mackie', '1978-10-23', 1, 13),
('Hayley', 'Law', '1992-11-18', 2, 14),
('Kiernan', 'Shipka', '1999-11-10', 2, 15),
('Ross', 'Lynch ', '1995-12-29', 1, 16),
('Lucy', 'Davis', '1973-02-17', 2, 17),
('Chance', 'Perdomo', '1996-08-19', 1, 18),
('Michelle', 'Gomez ', '1966-11-23', 2, 19),
('Jaz', 'Sinclair', '1994-06-22', 2, 20),
('Tati', 'Gabrielle', '1996-02-24', 2, 21),
('Adeline', 'Rudolph', '1995-02-10', 2, 22),
('Richard', 'Coyle', '1972-02-27', 1, 23),
('Miranda', 'Otto', '1967-12-16', 2, 24),
('Lachlan', 'Watson', '2001-01-01', 3, 25),
('Karl', 'Urban', '1972-07-07', 1, 26),
('Jack', 'Quaid', '1992-03-24', 1, 27),
('Antony', 'Starr', '1975-08-25', 1, 28),
('Erin', 'Moriarty', '1994-06-24', 2, 29),
('Dominique', 'McElligott', '1986-03-03', 2, 30),
('Jessie', 'Usher', '1992-02-29', 1, 31),
('Laz', 'Alonso', '1974-05-25', 1, 32),
('Chace', 'Crawford', '1985-07-18', 1, 33),
('Tomer', 'Capon', '1985-07-15', 1, 34),
('Karen', 'Fukuhara', '1992-02-10', 2, 35),
('Nathan', 'Mitchell', '1985-12-05', 1, 36),
('Elisabeth', 'Shue', '1963-08-06', 2, 37),
('Jennifer', 'Esposito', '1973-06-11', 2, 38),
('Colby', 'Minifie', '1992-08-10', 2, 39),
('Cameron', 'Crovetti', '2005-06-11', 1, 40),
('Bazingtonas', 'Blonigubas', '2020-04-29', 1, 43);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `amziaus_cenzas`
--

CREATE TABLE `amziaus_cenzas` (
  `id_amziaus_cenzas` int(11) NOT NULL,
  `name` char(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `amziaus_cenzas`
--

INSERT INTO `amziaus_cenzas` (`id_amziaus_cenzas`, `name`) VALUES
(1, 'ivairaus amziaus'),
(2, 'nuo 7 metu'),
(3, 'nuo 13 metu'),
(4, 'nuo 16 metu'),
(5, 'nuo 18 metu');

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `apdovanojimas`
--

CREATE TABLE `apdovanojimas` (
  `kategorija` varchar(50) NOT NULL,
  `nominantas` varchar(50) NOT NULL,
  `gavimo_metai` int(10) NOT NULL,
  `id_APDOVANOJIMAS` int(11) NOT NULL,
  `fk_TV_LAIDAid_TV_LAIDA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `apdovanojimas`
--

INSERT INTO `apdovanojimas` (`kategorija`, `nominantas`, `gavimo_metai`, `id_APDOVANOJIMAS`, `fk_TV_LAIDAid_TV_LAIDA`) VALUES
('Holy moly', 'Paulius Lozys', 2091, 27, 1),
('Best effects', 'Billy Dee', 2016, 30, 3),
('Outstanding Effects Simulations in an Episode', 'Philipp Kratzer', 2019, 42, 2),
('Epic', 'Hello', 2020, 43, 2);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `epizodas`
--

CREATE TABLE `epizodas` (
  `pavadinimas` varchar(50) NOT NULL,
  `aprasymas` varchar(255) NOT NULL,
  `direktorius` varchar(50) NOT NULL,
  `epizodo_numeris` int(11) NOT NULL,
  `id_EPIZODAS` int(11) NOT NULL,
  `fk_SEZONASid_SEZONAS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `epizodas`
--

INSERT INTO `epizodas` (`pavadinimas`, `aprasymas`, `direktorius`, `epizodo_numeris`, `id_EPIZODAS`, `fk_SEZONASid_SEZONAS`) VALUES
('Unauthorized Magic', 'A smart, geeky and socially awkward young man is amazed to realize that the Magic he\'s so passionate about is actually real, when he\'s unexpectedly invited to attend a college of magic in New York.', 'Mike Cahill', 1, 1, 1),
('The Source of Magic', 'Quentin is distraught as he faces expulsion for his involvement in an otherworldly attack on Brakebills, while Julia delves deeper into underground magic and takes a test to prove herself to the Hedge Witches.', 'Scott Smith', 2, 2, 1),
('Consequences of Advanced Spellcasting', 'Quentin and Julia have an unexpected - and volatile - reunion. Penny is overwhelmed by the power of his own psychic abilities and Alice is determined to find out what happened to her missing brother - at any cost.', 'Scott Smith', 3, 3, 1),
('The World in the Walls', 'Quentin wakes up in a mental hospital and must set his panic aside to seek the help of the one person he least trusts. Julia is hurt after her fallout with Quentin and commits to learning more powerful spells with the Hedge Witches.', 'James L. Conway', 4, 4, 1),
('Mendings, Major and Minor', 'Although everyone should be training for the upcoming Welter\'s Tournament, the students are each dealing with a personal distraction that keeps them from staying focused.', 'Bill Eagles', 5, 5, 1),
('Impractical Applications', 'The First Years are thrust into the old Brakebills tradition of The Trials, a midterm-slash-hazing ritual in which failing means flunking out for good. Meanwhile, in Brooklyn, Julia meets a fellow blacklisted Hedge Witch.', 'John Scott', 6, 6, 1),
('The Mayakovsky Circumstance', 'The students are taught by an overbearing teacher while back at Brakebills Elliott and Margon prepare for a debaucherous vacation.', 'Guy Norman Bee', 7, 7, 1),
('The Strangled Heart', 'Brakebills is thrown into chaos when Penny is violently attacked by someone they thought was a friend while Quentin tries to find a connection to The Beast. After entering a rehab facility, Julia considers giving up magic for good.', 'Jan Eliasberg', 8, 8, 1),
('The Writing Room', 'Quentin, Alice, Eliot and Penny travel to England to Plover\'s estate in search of a missing magic button, but what they find is a hauntingly terrifying vision of the author\'s true self. Julia, now out of rehab, searches for real meaning in her magic.', 'James L. Conway', 9, 9, 1),
('Homecoming', 'As Quentin and Alice try to save him, Penny learns that the Neitherlands is not as friendly as he thought. Julia attempts to join the Free Traders, an eclectic group of Magicians.', 'Joshua Butler', 10, 10, 1),
('Remedial Battle Magic', 'Prior to a showdown in Fillory, Quentin and crew get a crash course in Battle magic.', 'Amanda Tapping', 11, 11, 1),
('Thirty-Nine Graves', 'The students wake up with foggy memories and regret after a night of drinking; Penny reminds everyone that their lives depend on getting to The Neitherlands.', 'Guy Norman Bee', 12, 12, 1),
('Have You Brought Me Little Cakes', 'Quentin and Julia are using time magic to get to Fillory, where they try to catch up with the students who are 70 years ahead of them searching for the Beast.', 'Scott Smith', 13, 13, 1),
('Knight of Crowns', 'In the aftermath of their clash with The Beast, Quentin and his friends scramble for a new plan, while Julia and The Beast strike a dangerous deal.', 'Chris Fisher', 1, 14, 2),
('Hotel Spa Potions', 'Quentin, Alice, Penny and Margo seek a new weapon. Eliot struggles with being king. Julia and The Beast find an unexpected ally.', 'Chris Fisher', 2, 15, 2),
('Divine Elimination', 'Quentin and friends prepare to face The Beast again, while Julia conspires with The Beast and their new ally to lure and trap Reynard.', 'John Scott', 3, 16, 2),
('The Flying Forest', 'Quentin and Penny embark upon a quest. Margo works on a way to help Eliot. Julia seeks out an old friend\'s help.', 'Carol Banker', 4, 17, 2),
('Cheat Day', 'Life without magic proves difficult for Quentin. Julia deals with upsetting news. Eliot and Margo are faced with a new threat in Fillory. Penny returns to old stomping grounds.', 'Joshua Butler', 5, 18, 2),
('The Cock Barrens', 'Quentin teams up with Alice\'s dad. Margo uses her powers of diplomacy while Penny tries to save a kidnapped Fillory. Banishing Renard comes with some surprises.', 'Kate Woods', 6, 19, 2),
('Plan B', 'Julia and Kady enlist Quentin, Margo, Eliot and Penny for a magical heist.', 'Chris Fisher', 7, 20, 2),
('Word as Bond', 'Julia, Kady, Penny and Quentin set out to find another spawn of Reynard as Kady struggles to reveal to Julia the consequences of her recent procedure.', 'James L. Conway', 8, 21, 2),
('Lesser Evils', 'Dean Fogg and Professor Lipson attempt to rid Quentin of Alice\'s Niffin but he refuses to let Alice go.', 'Rebecca Johnson', 9, 22, 2),
('The Girl Who Told Time', 'The Royal Court of Fillory prepares for Eliot\'s nuptials as he endeavors to win over the Fillorians with the extravagant event.', 'Joshua Butler', 10, 23, 2),
('The Rattening', 'Quentin and Julia travel to the Underworld. Margo must deal with the fallout of her past decisions. Senator Gaines learns of his gift.', 'James L. Conway', 11, 24, 2),
('Ramifications', 'Alice and her shade are reassembled. Julia and Kady are determined to draw out Reynard. Elliot and Quentin are determined to return back to Fillory.', 'Chris Fisher', 12, 25, 2),
('We Have Brought You Little Cakes', 'A crisis comes to a head when the true power behind the troubles comes to party. Battles are won and wars are lost, as Q and the others must protect their kingdom. Alice makes a startling revelation and things may never be the same.', 'Chris Fisher', 13, 26, 2),
('Out of the Past', 'Waking up in a new body 250 years after his death, Takeshi Kovacs discovers he\'s been resurrected to help a titan of industry solve his own murder.', 'Miguel Sapochnik', 1, 27, 3),
('Fallen Angel', 'While Kovacs tracks down a man who sent Bancroft a death threat, Lt. Ortega bends the rules to keep tabs on his whereabouts.', 'Nick Hurran', 2, 28, 3),
('In a Lonely Place', 'Kovacs recruits an unlikely partner to watch his back during a banquet at the Bancroft home, where Ortega oversees the night\'s grisly entertainment.', 'Nick Hurran', 3, 29, 3),
('Force of Evil', 'Tortured by his captor, Kovacs taps into his Envoy training to survive. Ortega springs a surprise on her family for Día de los Muertos.', 'Alex Graves', 4, 30, 3),
('The Wrong Man', 'After learning his sleeve\'s identity, Kovacs demands the full story from Ortega. A tip from Poe leads to a major breakthrough in the Bancroft case.', 'Uta Briesewitz', 5, 31, 3),
('Man with My Face', 'With Ortega\'s fate hanging in the balance, Kovacs drops a bombshell on the Bancrofts. Later, he comes face to face with an unsettling opponent.', 'Alex Graves', 6, 32, 3),
('Nora Inu', 'As Kovacs reconnects with a figure from his past, his tangled history with the Protectorate, the Uprising and Quell plays out in flashbacks.', 'Andy Goddard', 7, 33, 3),
('Clash by Night', 'His world rocked, Kovacs requests a dipper to help him sew up the Bancroft case quickly. Ortega races to identify the mystery woman from Fight Drome.', 'Uta Briesewitz', 8, 34, 3),
('Rage in Heaven', 'After a devastating rampage, Kovacs and his allies hatch a bold - and very risky - scheme to infiltrate Head in the Clouds.', 'Peter Hoar', 9, 35, 3),
('The Killers', 'As a cornered Kovacs braces for a final showdown in the sky, a new hero emerges and more buried secrets come to light.', 'Peter Hoar', 10, 36, 3),
('Phantom Lady', 'Thirty years after the Bancroft case, a Meth tracks down Kovacs to offer him a job, a high-tech sleeve and a chance to see Quellcrist Falconer again.', 'Ciaran Donnelly', 1, 37, 4),
('Payment Deferred', 'As Col. Carrera takes charge of the murder investigation, Kovacs sets out to find Axley\'s bounty hunter, and Poe\'s memory glitches worsen.', 'Ciaran Donnelly', 2, 38, 4),
('Nightmare Alley', 'Kovacs contends with ghosts from his past as he\'s tortured by Carrera. Poe seeks help from a fellow AI. Trepp gets a lead on the man she\'s after.', 'M.J. Bassett', 3, 39, 4),
('Shadow of a Doubt', 'While the planet celebrates Harlan\'s Day, Kovacs hatches an escape plan, Quell pieces together fragments of her life, and Poe faces a reckoning.', 'M.J. Bassett', 4, 40, 4),
('I Wake Up Screaming', 'Carrera sends his secret weapon on a deadly mission. Kovacs and Trepp smuggle Quell out of the city. Poe takes a risky trip into virtual reality.', 'Jeremy Webb', 5, 41, 4),
('Bury Me Dead', 'As Quell reconnects to her past at Stronghold, she leads the clone into an underground chamber teeming with secrets. Gov. Harlan shows her true colors.', 'Jeremy Webb', 6, 42, 4),
('Experiment Perilous', 'When Quell\'s sleeve begins to shut down, Poe and Ms. Dig send her into VR, where Kovacs finally learns the truth about her deadly rampages.', 'Salli Richardson-Whitfield', 7, 43, 4),
('Broken Angels', 'With the fate of the whole planet on the line, Kovacs, Quell and team race to find Konrad Harlan and stop a catastrophic blast of Angelfire.', 'Salli Richardson-Whitfield', 8, 44, 4),
('Chapter One: October Country', 'While Greendale readies for a Halloween eclipse, Sabrina faces a crucial decision and Harvey makes an unexpected declaration.', 'Lee Toland Krieger', 1, 45, 5),
('Chapter Two: The Dark Baptism', 'A legendary guest visits Spellman Mortuary, Ambrose explores a grim revelation, and Sabrina stuns the coven with a shocking announcement.', 'Lee Toland Krieger', 2, 46, 5),
('Chapter Three: The Trial of Sabrina Spellman', 'As Sabrina confronts a long line of family secrets, Harvey faces turmoil at home - and shares a secret of his own.', 'Rob Seidenglanz', 3, 47, 5),
('Chapter Four: Witch Academy', 'Sabrina takes a weekend trip. Father Blackwood poses a pivotal question, Roz and Susie stage an impromptu - and unnerving - sleepover.', 'Rob Seidenglanz', 4, 48, 5),
('Chapter Five: Dreams in a Witch House', 'A mysterious demon wreaks havoc on Spellman Mortuary. Sabrina goes rogue and puts her own powers to the test.', 'Maggie Kiley', 5, 49, 5),
('Chapter Six: An Exorcism in Greendale', 'Harvey, Roz and Susie explore a mysterious force of evil. Sabrina digs deeper into Ms. Wardwell\'s intentions. Hilda pursues a new beginning.', 'Rachel Talalay', 6, 50, 5),
('Chapter Seven: Feast of Feasts', 'The coven prepares for an annual ritual as Harvey takes part in a Kinkle family tradition. Sabrina grows suspicious of lady Blackwood.', 'Viet Nguyen', 7, 51, 5),
('Chapter Eight: The Burial', 'A disaster rattles the Greendale community. Desperate to help, Sabrina attempts a new kind of dark magic - with the assistance of an unusual ally.', 'Maggie Kiley', 8, 52, 5),
('Chapter Nine: The Returned Man', 'Sabrina recruits Roz for a crucial mission. Susie reconnects with her past. Lord Blackwood challenges Aunt Zelda\'s authority.', 'Craig William Macneill', 9, 53, 5),
('Chapter Ten: The Witching Hour', 'A revolutionary attack divides the witches and mortals of Greendale, and Sabrina braces for a life-changing choice.', 'Rob Seidenglanz', 10, 54, 5),
('Chapter Eleven: A Midwinter\'s Tale', 'As the winter solstice approaches, Sabrina orchestrates an emotional seance with serious consequences, and Susie\'s merry plans turn menacing.', 'Jeff Woolnough', 11, 55, 5),
('The Name of the Game', 'When a Supe kills the love of his life, A/V salesman Hughie Campbell teams up with Billy Butcher, a vigilante hell-bent on punishing corrupt Supes -- and Hughie\'s life will never be the same again.', 'Dan Trachtenberg', 1, 56, 6),
('Cherry', 'The Boys get themselves a Superhero, Starlight gets payback, Homelander gets naughty, and a Senator gets naughtier.', 'Matt Shakman', 2, 57, 6),
('Get Some', 'It\'s the race of the century. A-Train versus Shockwave, vying for the title of World\'s Fastest Man. Meanwhile, the Boys are reunited and it feels so good.', 'Philip Sgriccia', 3, 58, 6),
('The Female of the Species', 'On a very special episode of The Boys... an hour of guts, gutterballs, airplane hijackings, madness, ghosts, and one very intriguing Female. Oh, and lots of heart -- both in the sentimental sense, and in the gory literal sense.', 'Frederick E.O. Toye', 4, 59, 6),
('Good for the Soul', 'The Boys head to the \"Believe\" Expo to follow a promising lead in their ongoing war against the Supes. There might -- MIGHT -- be a homicidal infant, but you\'ll have to see for yourself.', 'Stefan Schwartz', 5, 60, 6),
('The Innocents', 'SUPER IN AMERICA (2019). Vought Studios. Genre: Reality. Starring: Homelander, Queen Maeve, Black Noir, The Deep, A-Train, Starlight, Tara Reid, Billy Zane.', 'Jennifer Phang', 6, 61, 6),
('The Self-Preservation Society', 'Never trust a washed-up Supe -- the Boys learn this lesson the hard way. Meanwhile, Homelander digs into his past, Starlight discovers that love hurts, and if you\'re ever in Sandusky.', 'Daniel Attias', 7, 62, 6),
('You Found Me', 'Season Finale Time! Questions answered! Secrets revealed! Conflicts... conflicted! Characters exploded! And so much more!', 'Eric Kripke', 8, 63, 6),
('Chapter Twelve: The Epiphany', 'As Sabrina prepares for a spellbinding showcase, Susie embraces a series of new beginnings, and Ms. Wardwell finds greater purpose at Baxter High.', 'Kevin Rodney Sullivan', 1, 64, 7),
('Chapter Thirteen: The Passion of Sabrina Spellman', 'A sinister guest visits Spellman Mortuary. Theo faces a cast of cruel critics, and Roz and Harvey pursue an extra-steamy school assignment.', 'Michael Goi', 2, 65, 7),
('Chapter Fourteen: Lupercalia', 'Love and lust sweep through Greendale as Harvey surprises Roz with a sweet gift, and Sabrina explores a romantic ritual ... and her feelings for Nick.', 'Salli Richardson-Whitfield', 3, 66, 7),
('Chapter Fifteen: Doctor Cerberus\'s House of Horror', 'Sabrina, Theo, Roz and others attempt to navigate the lines between fact, fiction and fate when a mysterious stranger sets up shop in Cerberus Books.', 'Alex Garcia Lopez', 4, 67, 7),
('Chapter Sixteen: Blackwood', 'Tensions rise as Zelda and Father Blackwood\'s union draws near. Amid the chaos, Sabrina greets a familiar vision and Ambrose uncovers a dark truth.', 'Alex Pillai', 5, 68, 7),
('Chapter Seventeen: The Missionaries', 'As Hilda and Sabrina attempt to save Ambrose, Ms. Wardwell considers a crucial move, and a violent group of witch hunters targets the Church of Night.', 'Rob Seidenglanz', 6, 69, 7),
('Chapter Eighteen: The Miracles of Sabrina Spellman', 'On the heels of a most perplexing spectacle, Sabrina dives deeper into her newfound power, and Zelda slips into the role of Lady Blackwood.', 'Antonio Negret', 7, 70, 7),
('Chapter Nineteen: The Mandrake', 'An ominous discovery leads to a desperate search for answers -- and a risky spell for Sabrina. Meanwhile, Father Blackwood makes a bold announcement.', 'Kevin Rodney Sullivan', 8, 71, 7),
('Chapter Twenty: Mephisto Waltz', 'Light and night cross paths once more as Greendale faces the Dark Lord\'s prophecy and Prudence challenges Father Blackwood\'s ruthless plan.', 'Rob Seidenglanz', 9, 72, 7);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `kategorija`
--

CREATE TABLE `kategorija` (
  `id_kategorija` int(11) NOT NULL,
  `name` char(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `kategorija`
--

INSERT INTO `kategorija` (`id_kategorija`, `name`) VALUES
(1, 'veiksmas'),
(2, 'komedija'),
(3, 'vaikams'),
(4, 'siaubas'),
(5, 'istorinis'),
(6, 'mistika'),
(7, 'fantastika');

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `kurejas`
--

CREATE TABLE `kurejas` (
  `vardas` varchar(50) NOT NULL,
  `pavarde` varchar(50) NOT NULL,
  `gimimo_metai` date NOT NULL,
  `role` varchar(50) NOT NULL,
  `lytis` int(11) NOT NULL,
  `id_KUREJAS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `kurejas`
--

INSERT INTO `kurejas` (`vardas`, `pavarde`, `gimimo_metai`, `role`, `lytis`, `id_KUREJAS`) VALUES
('Sera', 'Gamble', '1983-09-20', 'Writer', 2, 1),
('John', 'McNamara', '1962-05-02', 'Writer', 1, 2),
('Leata', 'Kalogridis', '1965-10-30', 'Writer', 2, 3),
('Nevin', 'Densham', '1980-07-26', 'Writer', 1, 4),
('Craig', 'Powell', '1971-10-04', 'Cinematographer', 1, 5),
('Roberto', 'Aguirre-Sacasa', '1976-05-16', 'Writer', 1, 6),
('Angus', 'Strathie', '1986-04-18', 'Costume Designer', 1, 7),
('Anne', 'Saunders', '1978-04-15', 'Writer', 2, 8),
('Eric', 'Kripke', '1974-06-24', 'Producer', 1, 9),
('Bazingtonas', 'Bazinga', '0001-01-01', 'Writter/ScreenWritter', 1, 10),
('Hello', 'World', '2001-01-01', 'Writter/ScreenWritter', 2, 12);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `kuria`
--

CREATE TABLE `kuria` (
  `fk_TV_LAIDAid_TV_LAIDA` int(11) NOT NULL,
  `fk_KUREJASid_KUREJAS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `kuria`
--

INSERT INTO `kuria` (`fk_TV_LAIDAid_TV_LAIDA`, `fk_KUREJASid_KUREJAS`) VALUES
(1, 1),
(1, 2),
(1, 10),
(2, 3),
(2, 4),
(3, 5),
(3, 6),
(3, 7),
(3, 12),
(4, 1),
(4, 8),
(4, 9);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `laidos_busena`
--

CREATE TABLE `laidos_busena` (
  `id_laidos_busena` int(11) NOT NULL,
  `name` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `laidos_busena`
--

INSERT INTO `laidos_busena` (`id_laidos_busena`, `name`) VALUES
(1, 'rodoma'),
(2, 'nutraukta'),
(3, 'pasibaigusi'),
(4, 'sustabdyta');

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `lytis`
--

CREATE TABLE `lytis` (
  `id_lytis` int(11) NOT NULL,
  `name` char(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `lytis`
--

INSERT INTO `lytis` (`id_lytis`, `name`) VALUES
(1, 'vyras'),
(2, 'moteris'),
(3, 'kita');

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `salis`
--

CREATE TABLE `salis` (
  `pavadinimas` varchar(50) NOT NULL,
  `gyventoju_skaicius` int(11) NOT NULL,
  `id_SALIS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `salis`
--

INSERT INTO `salis` (`pavadinimas`, `gyventoju_skaicius`, `id_SALIS`) VALUES
('China', 1401565520, 1),
('India', 1359279800, 2),
('United States', 329374114, 3),
('Indonesia', 266911900, 4),
('Brazil', 211195497, 5),
('Pakistan', 208215732, 6),
('Nigeria', 200963599, 7),
('Bangladesh', 168191888, 8),
('Russia', 146780720, 9),
('Mexico', 126577691, 10),
('Japan', 126010000, 11),
('Gargilog', 1544441414, 14);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `sezonas`
--

CREATE TABLE `sezonas` (
  `isleidimo_data` int(10) NOT NULL,
  `pabaigos_data` int(10) DEFAULT NULL,
  `sezono_numeris` int(11) NOT NULL,
  `ivertinimas` int(3) NOT NULL,
  `id_SEZONAS` int(11) NOT NULL,
  `fk_TV_LAIDAid_TV_LAIDA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `sezonas`
--

INSERT INTO `sezonas` (`isleidimo_data`, `pabaigos_data`, `sezono_numeris`, `ivertinimas`, `id_SEZONAS`, `fk_TV_LAIDAid_TV_LAIDA`) VALUES
(2015, 2015, 1, 7, 1, 1),
(2017, 2018, 2, 8, 2, 1),
(2018, 2018, 1, 6, 3, 2),
(2020, 2020, 2, 9, 4, 2),
(2018, 2018, 1, 8, 5, 3),
(2019, 2019, 1, 9, 6, 4),
(2019, 2019, 2, 8, 7, 3);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `transliuoja`
--

CREATE TABLE `transliuoja` (
  `fk_TV_LAIDAid_TV_LAIDA` int(11) NOT NULL,
  `fk_TV_TINKLASid_TV_TINKLAS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `transliuoja`
--

INSERT INTO `transliuoja` (`fk_TV_LAIDAid_TV_LAIDA`, `fk_TV_TINKLASid_TV_TINKLAS`) VALUES
(1, 1),
(2, 2),
(3, 2),
(4, 3);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `tv_laida`
--

CREATE TABLE `tv_laida` (
  `pavadinimas` varchar(50) NOT NULL,
  `trukme` int(11) NOT NULL,
  `isleidimo_metai` date NOT NULL,
  `reitingai` float NOT NULL,
  `ziurovu_vidutinis_ivertinimas` float NOT NULL,
  `aprasymas` varchar(255) NOT NULL,
  `busena` int(11) NOT NULL,
  `zanras` int(11) NOT NULL,
  `amziaus_reikalavimas` int(11) NOT NULL,
  `id_TV_LAIDA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `tv_laida`
--

INSERT INTO `tv_laida` (`pavadinimas`, `trukme`, `isleidimo_metai`, `reitingai`, `ziurovu_vidutinis_ivertinimas`, `aprasymas`, `busena`, `zanras`, `amziaus_reikalavimas`, `id_TV_LAIDA`) VALUES
('The Magicians', 60, '2015-08-11', 69, 6, 'After being recruited to a secretive academy, a group of students discover that the magic they read about as children is very real-and more dangerous than they ever imagined.', 4, 1, 4, 1),
('Altered Carbon', 60, '2016-03-01', 27, 8, 'Set in a future where consciousness is digitized and stored, a prisoner returns to life in a new body and must solve a mind-bending murder to win his freedom.', 1, 1, 5, 2),
('Chilling Adventures of Sabrina', 60, '2018-11-08', 55, 7, 'As her 16th birthday nears, Sabrina must choose between the witch world of her family and the human world of her friends. Based on the Archie comic.', 1, 7, 4, 3),
('The Boys', 60, '2019-05-06', 59, 9, 'A group of vigilantes set out to take down corrupt superheroes who abuse their superpowers.', 1, 1, 5, 4),
('BAZINGA', 23, '2020-01-25', 56, 7, 'SAVE ME', 1, 1, 1, 13),
('Regular show', 10, '2008-07-10', 1200, 8, 'A show about a simp', 3, 3, 1, 15);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `tv_tinklas`
--

CREATE TABLE `tv_tinklas` (
  `pavadinimas` varchar(50) NOT NULL,
  `adresas` varchar(50) NOT NULL,
  `ziurovu_skaicius` int(11) NOT NULL,
  `savininkas` varchar(50) NOT NULL,
  `vadovas` varchar(50) NOT NULL,
  `id_TV_TINKLAS` int(11) NOT NULL,
  `fk_SALISid_SALIS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `tv_tinklas`
--

INSERT INTO `tv_tinklas` (`pavadinimas`, `adresas`, `ziurovu_skaicius`, `savininkas`, `vadovas`, `id_TV_TINKLAS`, `fk_SALISid_SALIS`) VALUES
('Syfy', 'Comcast Building, New York City, New York', 1199000, 'NBCUniversal', 'Steve Burke', 1, 3),
('Netflix', 'Los Gatos, California, U.S.', 169000000, 'Reed Hastings', 'Reed Hastings', 2, 3),
('Amazon Prime', 'Seattle, Washington, U.S.', 150000000, 'Amazon', 'Jeff Bezos', 3, 3);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `veikejas`
--

CREATE TABLE `veikejas` (
  `vardas` varchar(50) NOT NULL,
  `pavarde` varchar(50) DEFAULT NULL,
  `lytis` int(11) NOT NULL,
  `id_VEIKEJAI` int(11) NOT NULL,
  `fk_TV_LAIDAid_TV_LAIDA` int(11) NOT NULL,
  `fk_AKTORIUSid_AKTORIUS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `veikejas`
--

INSERT INTO `veikejas` (`vardas`, `pavarde`, `lytis`, `id_VEIKEJAI`, `fk_TV_LAIDAid_TV_LAIDA`, `fk_AKTORIUSid_AKTORIUS`) VALUES
('Josh', 'Hoberman', 1, 1, 1, 11),
('Julia', 'Wicker', 2, 2, 1, 2),
('Eliot', 'Waugh', 1, 3, 1, 3),
('Penny', 'Adiyodi', 1, 4, 1, 4),
('Margo', 'Hanson', 2, 5, 1, 5),
('Alice', 'Quinn', 2, 6, 1, 6),
('Quentin', 'Coldwater', 1, 7, 1, 7),
('Kady', 'Diaz', 2, 8, 1, 8),
('Fen', NULL, 2, 9, 1, 9),
('Henry', 'Fog', 1, 10, 1, 10),
('Poe', NULL, 1, 11, 2, 12),
('Takeshi', 'Kovacs', 1, 12, 2, 13),
('Lizzie', 'Elliot', 2, 13, 2, 14),
('Sabrina', 'Spellman', 2, 14, 3, 15),
('Harvey', 'Kinkle', 2, 15, 3, 16),
('Hilda', 'Spellman', 2, 16, 3, 17),
('Ambrose', 'Spellman', 1, 17, 3, 18),
('Mary', 'Wardwell', 2, 18, 3, 19),
('Rosalind', 'Walker', 2, 19, 3, 20),
('Prudence', 'Night', 2, 20, 3, 21),
('Agatha', NULL, 2, 21, 3, 22),
('Faustus', 'Blackwood', 1, 22, 3, 23),
('Zelda', 'Spellman', 2, 23, 3, 24),
('Theo', 'Putnam', 1, 24, 3, 25),
('Billy', 'Butcher', 1, 25, 4, 26),
('Hughie', 'Campbell', 1, 26, 4, 27),
('Homelander', NULL, 1, 27, 4, 28),
('Annie', 'January', 2, 28, 4, 29),
('Queen', 'Maeve', 2, 29, 4, 30),
('A-Train', NULL, 1, 30, 4, 31),
('Mother\'s Milk', NULL, 1, 31, 4, 32),
('The Deep', NULL, 1, 32, 4, 33),
('Frenchie', NULL, 1, 33, 4, 34),
('The Female', NULL, 2, 34, 4, 35),
('Black Noir', NULL, 1, 35, 4, 36),
('Madelyn', 'Stillwell', 2, 36, 4, 37),
('Susan', 'Raynor', 2, 37, 4, 38),
('Ashley', 'Barrett', 2, 38, 4, 39),
('Ryan', 'Butcher', 1, 39, 4, 40);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aktorius`
--
ALTER TABLE `aktorius`
  ADD PRIMARY KEY (`id_AKTORIUS`),
  ADD KEY `lytis` (`lytis`);

--
-- Indexes for table `amziaus_cenzas`
--
ALTER TABLE `amziaus_cenzas`
  ADD PRIMARY KEY (`id_amziaus_cenzas`);

--
-- Indexes for table `apdovanojimas`
--
ALTER TABLE `apdovanojimas`
  ADD PRIMARY KEY (`id_APDOVANOJIMAS`),
  ADD KEY `gauna` (`fk_TV_LAIDAid_TV_LAIDA`);

--
-- Indexes for table `epizodas`
--
ALTER TABLE `epizodas`
  ADD PRIMARY KEY (`id_EPIZODAS`),
  ADD KEY `priklauso` (`fk_SEZONASid_SEZONAS`);

--
-- Indexes for table `kategorija`
--
ALTER TABLE `kategorija`
  ADD PRIMARY KEY (`id_kategorija`);

--
-- Indexes for table `kurejas`
--
ALTER TABLE `kurejas`
  ADD PRIMARY KEY (`id_KUREJAS`),
  ADD KEY `lytis` (`lytis`);

--
-- Indexes for table `kuria`
--
ALTER TABLE `kuria`
  ADD PRIMARY KEY (`fk_TV_LAIDAid_TV_LAIDA`,`fk_KUREJASid_KUREJAS`),
  ADD KEY `fk_KUREJASid_KUREJAS` (`fk_KUREJASid_KUREJAS`);

--
-- Indexes for table `laidos_busena`
--
ALTER TABLE `laidos_busena`
  ADD PRIMARY KEY (`id_laidos_busena`);

--
-- Indexes for table `lytis`
--
ALTER TABLE `lytis`
  ADD PRIMARY KEY (`id_lytis`);

--
-- Indexes for table `salis`
--
ALTER TABLE `salis`
  ADD PRIMARY KEY (`id_SALIS`);

--
-- Indexes for table `sezonas`
--
ALTER TABLE `sezonas`
  ADD PRIMARY KEY (`id_SEZONAS`),
  ADD KEY `turi` (`fk_TV_LAIDAid_TV_LAIDA`);

--
-- Indexes for table `transliuoja`
--
ALTER TABLE `transliuoja`
  ADD PRIMARY KEY (`fk_TV_LAIDAid_TV_LAIDA`,`fk_TV_TINKLASid_TV_TINKLAS`),
  ADD KEY `fk_TV_TINKLASid_TV_TINKLAS` (`fk_TV_TINKLASid_TV_TINKLAS`);

--
-- Indexes for table `tv_laida`
--
ALTER TABLE `tv_laida`
  ADD PRIMARY KEY (`id_TV_LAIDA`),
  ADD KEY `busena` (`busena`),
  ADD KEY `zanras` (`zanras`),
  ADD KEY `amziaus_reikalavimas` (`amziaus_reikalavimas`);

--
-- Indexes for table `tv_tinklas`
--
ALTER TABLE `tv_tinklas`
  ADD PRIMARY KEY (`id_TV_TINKLAS`),
  ADD KEY `valdo` (`fk_SALISid_SALIS`);

--
-- Indexes for table `veikejas`
--
ALTER TABLE `veikejas`
  ADD PRIMARY KEY (`id_VEIKEJAI`),
  ADD KEY `lytis` (`lytis`),
  ADD KEY `dalyvauja` (`fk_TV_LAIDAid_TV_LAIDA`),
  ADD KEY `vaidina` (`fk_AKTORIUSid_AKTORIUS`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aktorius`
--
ALTER TABLE `aktorius`
  MODIFY `id_AKTORIUS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT for table `apdovanojimas`
--
ALTER TABLE `apdovanojimas`
  MODIFY `id_APDOVANOJIMAS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT for table `epizodas`
--
ALTER TABLE `epizodas`
  MODIFY `id_EPIZODAS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=73;

--
-- AUTO_INCREMENT for table `kurejas`
--
ALTER TABLE `kurejas`
  MODIFY `id_KUREJAS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `salis`
--
ALTER TABLE `salis`
  MODIFY `id_SALIS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `sezonas`
--
ALTER TABLE `sezonas`
  MODIFY `id_SEZONAS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `tv_laida`
--
ALTER TABLE `tv_laida`
  MODIFY `id_TV_LAIDA` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `tv_tinklas`
--
ALTER TABLE `tv_tinklas`
  MODIFY `id_TV_TINKLAS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `veikejas`
--
ALTER TABLE `veikejas`
  MODIFY `id_VEIKEJAI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- Apribojimai eksportuotom lentelėm
--

--
-- Apribojimai lentelei `aktorius`
--
ALTER TABLE `aktorius`
  ADD CONSTRAINT `aktorius_ibfk_1` FOREIGN KEY (`lytis`) REFERENCES `lytis` (`id_lytis`);

--
-- Apribojimai lentelei `apdovanojimas`
--
ALTER TABLE `apdovanojimas`
  ADD CONSTRAINT `gauna` FOREIGN KEY (`fk_TV_LAIDAid_TV_LAIDA`) REFERENCES `tv_laida` (`id_TV_LAIDA`) ON DELETE CASCADE;

--
-- Apribojimai lentelei `epizodas`
--
ALTER TABLE `epizodas`
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_SEZONASid_SEZONAS`) REFERENCES `sezonas` (`id_SEZONAS`);

--
-- Apribojimai lentelei `kurejas`
--
ALTER TABLE `kurejas`
  ADD CONSTRAINT `kurejas_ibfk_1` FOREIGN KEY (`lytis`) REFERENCES `lytis` (`id_lytis`);

--
-- Apribojimai lentelei `kuria`
--
ALTER TABLE `kuria`
  ADD CONSTRAINT `kuria` FOREIGN KEY (`fk_TV_LAIDAid_TV_LAIDA`) REFERENCES `tv_laida` (`id_TV_LAIDA`) ON DELETE CASCADE,
  ADD CONSTRAINT `kuria_ibfk_1` FOREIGN KEY (`fk_KUREJASid_KUREJAS`) REFERENCES `kurejas` (`id_KUREJAS`) ON DELETE CASCADE;

--
-- Apribojimai lentelei `sezonas`
--
ALTER TABLE `sezonas`
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_TV_LAIDAid_TV_LAIDA`) REFERENCES `tv_laida` (`id_TV_LAIDA`);

--
-- Apribojimai lentelei `transliuoja`
--
ALTER TABLE `transliuoja`
  ADD CONSTRAINT `transliuoja` FOREIGN KEY (`fk_TV_LAIDAid_TV_LAIDA`) REFERENCES `tv_laida` (`id_TV_LAIDA`),
  ADD CONSTRAINT `transliuoja_ibfk_1` FOREIGN KEY (`fk_TV_TINKLASid_TV_TINKLAS`) REFERENCES `tv_tinklas` (`id_TV_TINKLAS`);

--
-- Apribojimai lentelei `tv_laida`
--
ALTER TABLE `tv_laida`
  ADD CONSTRAINT `tv_laida_ibfk_1` FOREIGN KEY (`busena`) REFERENCES `laidos_busena` (`id_laidos_busena`),
  ADD CONSTRAINT `tv_laida_ibfk_2` FOREIGN KEY (`zanras`) REFERENCES `kategorija` (`id_kategorija`),
  ADD CONSTRAINT `tv_laida_ibfk_3` FOREIGN KEY (`amziaus_reikalavimas`) REFERENCES `amziaus_cenzas` (`id_amziaus_cenzas`);

--
-- Apribojimai lentelei `tv_tinklas`
--
ALTER TABLE `tv_tinklas`
  ADD CONSTRAINT `valdo` FOREIGN KEY (`fk_SALISid_SALIS`) REFERENCES `salis` (`id_SALIS`);

--
-- Apribojimai lentelei `veikejas`
--
ALTER TABLE `veikejas`
  ADD CONSTRAINT `dalyvauja` FOREIGN KEY (`fk_TV_LAIDAid_TV_LAIDA`) REFERENCES `tv_laida` (`id_TV_LAIDA`),
  ADD CONSTRAINT `vaidina` FOREIGN KEY (`fk_AKTORIUSid_AKTORIUS`) REFERENCES `aktorius` (`id_AKTORIUS`),
  ADD CONSTRAINT `veikejas_ibfk_1` FOREIGN KEY (`lytis`) REFERENCES `lytis` (`id_lytis`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
