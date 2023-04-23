DECLARE @mergeError int;
DECLARE @mergeCount int;

SET NOCOUNT ON
SET IDENTITY_INSERT [Monkey] ON

MERGE INTO [Monkey] AS Target
USING (VALUES
(1, 'Baboon', 'Africa & Asia', 
	  'Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.',
	  'https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Portrait_Of_A_Baboon.jpg/314px-Portrait_Of_A_Baboon.jpg',
	  10000, -8.783195, 34.508523),
(2, 'Capuchin Monkey', 'Central & South America', 
	  'The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.',
	  'https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg',
	  23000, 12.769013, -85.602364),
(3, 'Blue Monkey', 'Central and East Africa', 
	  'The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia',
	  'https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg',
	  12000, 1.957709, 37.297204),
(4, 'Squirrel Monkey', 'Central & South America', 
	  'The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.',
	  'https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg',
	  11000, -8.783195, -55.491477),
(5, 'Golden Lion Tamarin', 'Brazil', 
	  'The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.',
	  'https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg',
	  19000, -14.235004, -51.92528),
(6, 'Howler Monkey', 'South America', 
	  'Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae',
	  'https://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Alouatta_guariba.jpg/200px-Alouatta_guariba.jpg',
	  8000, -8.783195, -55.491477),
(7, 'Japanese Macaque', 'Japan', 
	  'The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each',
	  'https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Macaca_fuscata_fuscata1.jpg/220px-Macaca_fuscata_fuscata1.jpg',
	  1000, 36.204824, 138.252924),
(8, 'Mandrill', 'Southern Cameroon, Gabon, Equatorial Guinea, and Congo', 
	  'The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.',
	  'https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Mandrill_at_san_francisco_zoo.jpg/220px-Mandrill_at_san_francisco_zoo.jpg',
	  17000, 7.369722, 12.354722),
(9, 'Proboscis Monkey', 'Borneo', 
	  'The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.',
	  'https://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Proboscis_Monkey_in_Borneo.jpg/250px-Proboscis_Monkey_in_Borneo.jpg',
	  15000, 0.961883, 114.55485),	  
(10, 'MiMo', 'Romania', 
	  'This little trouble maker lives in Iasi with Mircea and loves traveling on adventures. He is a .NET fan !', 
	  'https://avatars.githubusercontent.com/u/87313735?s=400&u=b2908eb867b46cc4709608123cae7d5ccd5e1d92&v=4',
	  1, 47.157090, 27.607738),
(11, 'Red-shanked douc', 'Vietnam', 
	  'The red-shanked douc is a species of Old World monkey, among the most colourful of all primates. The douc is an arboreal and diurnal monkey that eats and sleeps in the trees of the forest.',
	  'https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg',
	  1300, 16.111648, 108.262122)  
) AS Source ([Id],[Name], [Location], [Details], [Image], [Population], [Latitude], [Longitude])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED BY TARGET THEN
 INSERT([Id],[Name], [Location], [Details], [Image], [Population], [Latitude], [Longitude])
VALUES(Source.[Id], Source.[Name], Source.[Location], Source.[Details], Source.[Image], Source.[Population], Source.[Latitude], Source.[Longitude]);


SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
IF @mergeError != 0
BEGIN
 PRINT 'An error occurred in MERGE for Monkey. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100));
END
ELSE
BEGIN
	PRINT 'Monkey rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
END
 
SET IDENTITY_INSERT [Monkey] OFF
SET NOCOUNT OFF

GO
