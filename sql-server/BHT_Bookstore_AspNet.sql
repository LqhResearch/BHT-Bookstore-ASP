﻿CREATE DATABASE BHT_Bookstore
GO

USE BHT_Bookstore
GO

CREATE TABLE AccountTypes
(
	AccountTypeID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	AccountTypeName NVARCHAR(25) NOT NULL
)
GO

INSERT INTO AccountTypes (AccountTypeName) VALUES 
(N'Quản trị viên'),
(N'Nhân viên'),
(N'Thành viên');
GO

CREATE TABLE Users
(
	Username NVARCHAR(64) NOT NULL PRIMARY KEY,
	Password VARCHAR(64),
	Fullname NVARCHAR(64),
	Phone VARCHAR(11),
	Email VARCHAR(64) NOT NULL, -- Có thể đăng nhập bằng Email
	Avatar NVARCHAR(255),
	Money INT DEFAULT 0,
	Status BIT DEFAULT 1, -- 1: hoạt động -- 0: khoá
	CreatedAt DATETIME DEFAULT GETDATE(),
	AccountTypeID INT NOT NULL,

	FOREIGN KEY (AccountTypeID) REFERENCES AccountTypes (AccountTypeID)
)
GO

-- Username: Admin, QH -- Password: 123
INSERT INTO Users VALUES ('Admin', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Quản trị viên', '0123456789', 'admin@gmail.com', '/assets/img/admin.png', 0, 1, GETDATE(), 1)
INSERT INTO Users VALUES ('QH', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Quốc Hưng', '0987654321', 'qh@gmail.com', '/assets/img/user.png', 0, 0, GETDATE(), 3)
GO

CREATE TABLE Languages
(
	LanguageID VARCHAR(8) NOT NULL PRIMARY KEY,
	LanguageName NVARCHAR(50)
)
GO

INSERT INTO Languages VALUES
('aa', N'Tiếng Afar'),
('ab', N'Tiếng Abkhazia'),
('ace', N'Tiếng Achinese'),
('ach', N'Tiếng Acoli'),
('ada', N'Tiếng Adangme'),
('ady', N'Tiếng Adyghe'),
('ae', N'Tiếng Avestan'),
('aeb', N'Tunisian Arabic'),
('af', N'Tiếng Nam Phi'),
('afh', N'Tiếng Afrihili'),
('agq', N'Tiếng Aghem'),
('ain', N'Tiếng Ainu'),
('ak', N'Tiếng Akan'),
('akk', N'Tiếng Akkadia'),
('akz', N'Alabama'),
('ale', N'Tiếng Aleut'),
('aln', N'Gheg Albanian'),
('alt', N'Tiếng Altai Miền Nam'),
('am', N'Tiếng Amharic'),
('an', N'Tiếng Aragon'),
('ang', N'Tiếng Anh cổ'),
('anp', N'Tiếng Angika'),
('ar', N'Tiếng Ả Rập'),
('arc', N'Tiếng Aramaic'),
('arn', N'Tiếng Araucanian'),
('aro', N'Araona'),
('arp', N'Tiếng Arapaho'),
('arq', N'Algerian Arabic'),
('arw', N'Tiếng Arawak'),
('ary', N'Moroccan Arabic'),
('arz', N'Egyptian Arabic'),
('ar_001', N'Tiếng Ả Rập Hiện đại'),
('as', N'Tiếng Assam'),
('asa', N'Tiếng Asu'),
('ase', N'American Sign Language'),
('ast', N'Tiếng Asturias'),
('av', N'Tiếng Avaric'),
('avk', N'Kotava'),
('awa', N'Tiếng Awadhi'),
('ay', N'Tiếng Aymara'),
('az', N'Tiếng Azerbaijan'),
('azb', N'South Azerbaijani'),
('ba', N'Tiếng Bashkir'),
('bal', N'Tiếng Baluchi'),
('ban', N'Tiếng Bali'),
('bar', N'Bavarian'),
('bas', N'Tiếng Basaa'),
('bax', N'Tiếng Bamun'),
('bbc', N'Batak Toba'),
('bbj', N'Tiếng Ghomala'),
('be', N'Tiếng Belarus'),
('bej', N'Tiếng Beja'),
('bem', N'Tiếng Bemba'),
('bew', N'Betawi'),
('bez', N'Tiếng Bena'),
('bfd', N'Tiếng Bafut'),
('bfq', N'Badaga'),
('bg', N'Tiếng Bulgaria'),
('bho', N'Tiếng Bhojpuri'),
('bi', N'Tiếng Bislama'),
('bik', N'Tiếng Bikol'),
('bin', N'Tiếng Bini'),
('bjn', N'Banjar'),
('bkm', N'Tiếng Kom'),
('bla', N'Tiếng Siksika'),
('bm', N'Tiếng Bambara'),
('bn', N'Tiếng Bengali'),
('bo', N'Tiếng Tây Tạng'),
('bpy', N'Bishnupriya'),
('bqi', N'Bakhtiari'),
('br', N'Tiếng Breton'),
('bra', N'Tiếng Braj'),
('brh', N'Brahui'),
('brx', N'Tiếng Bodo'),
('bs', N'Tiếng Nam Tư'),
('bss', N'Tiếng Akoose'),
('bua', N'Tiếng Buriat'),
('bug', N'Tiếng Bugin'),
('bum', N'Tiếng Bulu'),
('byn', N'Tiếng Blin'),
('byv', N'Tiếng Medumba'),
('ca', N'Tiếng Catalan'),
('cad', N'Tiếng Caddo'),
('car', N'Tiếng Carib'),
('cay', N'Tiếng Cayuga'),
('cch', N'Tiếng Atsam'),
('ce', N'Tiếng Chechen'),
('ceb', N'Tiếng Cebuano'),
('cgg', N'Tiếng Chiga'),
('ch', N'Tiếng Chamorro'),
('chb', N'Tiếng Chibcha'),
('chg', N'Tiếng Chagatai'),
('chk', N'Tiếng Chuuk'),
('chm', N'Tiếng Mari'),
('chn', N'Biệt ngữ Chinook'),
('cho', N'Tiếng Choctaw'),
('chp', N'Tiếng Chipewyan'),
('chr', N'Tiếng Cherokee'),
('chy', N'Tiếng Cheyenne'),
('ckb', N'Tiếng Kurd Sorani'),
('co', N'Tiếng Corsica'),
('cop', N'Tiếng Coptic'),
('cps', N'Capiznon'),
('cr', N'Tiếng Cree'),
('crh', N'Tiếng Thổ Nhĩ Kỳ Crimean'),
('cs', N'Tiếng Séc'),
('csb', N'Tiếng Kashubia'),
('cu', N'Tiếng Slavơ Nhà thờ'),
('cv', N'Tiếng Chuvash'),
('cy', N'Tiếng Wales'),
('da', N'Tiếng Đan Mạch'),
('dak', N'Tiếng Dakota'),
('dar', N'Tiếng Dargwa'),
('dav', N'Tiếng Taita'),
('de', N'Tiếng Đức'),
('del', N'Tiếng Delaware'),
('den', N'Tiếng Slave'),
('de_AT', N'Austrian German'),
('de_CH', N'Tiếng Thượng Giéc-man (Thụy Sĩ)'),
('dgr', N'Tiếng Dogrib'),
('din', N'Tiếng Dinka'),
('dje', N'Tiếng Zarma'),
('doi', N'Tiếng Dogri'),
('dsb', N'Tiếng Hạ Sorbia'),
('dtp', N'Central Dusun'),
('dua', N'Tiếng Duala'),
('dum', N'Tiếng Hà Lan Trung cổ'),
('dv', N'Tiếng Divehi'),
('dyo', N'Tiếng Jola-Fonyi'),
('dyu', N'Tiếng Dyula'),
('dz', N'Tiếng Dzongkha'),
('dzg', N'Tiếng Dazaga'),
('ebu', N'Tiếng Embu'),
('ee', N'Tiếng Ewe'),
('efi', N'Tiếng Efik'),
('egl', N'Emilian'),
('egy', N'Tiếng Ai Cập cổ'),
('eka', N'Tiếng Ekajuk'),
('el', N'Tiếng Hy Lạp'),
('elx', N'Tiếng Elamite'),
('en', N'Tiếng Anh'),
('enm', N'Tiếng Anh Trung cổ'),
('en_AU', N'Australian English'),
('en_CA', N'Canadian English'),
('en_GB', N'Tiếng Anh (Anh)'),
('en_US', N'Tiếng Anh (Mỹ)'),
('eo', N'Tiếng Quốc Tế Ngữ'),
('es', N'Tiếng Tây Ban Nha'),
('esu', N'Central Yupik'),
('es_419', N'Tiếng Tây Ban Nha (Mỹ La tinh)'),
('es_ES', N'European Spanish'),
('es_MX', N'Mexican Spanish'),
('et', N'Tiếng Estonia'),
('eu', N'Tiếng Basque'),
('ewo', N'Tiếng Ewondo'),
('ext', N'Extremaduran'),
('fa', N'Tiếng Ba Tư'),
('fan', N'Tiếng Fang'),
('fat', N'Tiếng Fanti'),
('ff', N'Tiếng Fulah'),
('fi', N'Tiếng Phần Lan'),
('fil', N'Tiếng Philipin'),
('fit', N'Tornedalen Finnish'),
('fj', N'Tiếng Fiji'),
('fo', N'Tiếng Faore'),
('fon', N'Tiếng Fon'),
('fr', N'Tiếng Pháp'),
('frc', N'Cajun French'),
('frm', N'Tiếng Pháp Trung cổ'),
('fro', N'Tiếng Pháp cổ'),
('frp', N'Arpitan'),
('frr', N'Tiếng Frisian Miền Bắc'),
('frs', N'Tiếng Frisian Miền Đông'),
('fr_CA', N'Canadian French'),
('fr_CH', N'Swiss French'),
('fur', N'Tiếng Friulian'),
('fy', N'Tiếng Frisia'),
('ga', N'Tiếng Ai-len'),
('gaa', N'Tiếng Ga'),
('gag', N'Tiếng Gagauz'),
('gan', N'Gan Chinese'),
('gay', N'Tiếng Gayo'),
('gba', N'Tiếng Gbaya'),
('gbz', N'Zoroastrian Dari'),
('gd', N'Tiếng Xentơ (Xcốt len)'),
('gez', N'Tiếng Geez'),
('gil', N'Tiếng Gilbert'),
('gl', N'Tiếng Galician'),
('glk', N'Gilaki'),
('gmh', N'Tiếng Thượng Giéc-man Trung cổ'),
('gn', N'Tiếng Guarani'),
('goh', N'Tiếng Thượng Giéc-man cổ'),
('gom', N'Goan Konkani'),
('gon', N'Tiếng Gondi'),
('gor', N'Tiếng Gorontalo'),
('got', N'Tiếng Gô-tích'),
('grb', N'Tiếng Grebo'),
('grc', N'Tiếng Hy Lạp cổ'),
('gsw', N'Tiếng Đức (Thụy Sĩ)'),
('gu', N'Tiếng Gujarati'),
('guc', N'Wayuu'),
('gur', N'Frafra'),
('guz', N'Tiếng Gusii'),
('gv', N'Tiếng Manx'),
('gwi', N'Tiếng Gwichʼin'),
('ha', N'Tiếng Hausa'),
('hai', N'Tiếng Haida'),
('hak', N'Hakka Chinese'),
('haw', N'Tiếng Hawaii'),
('he', N'Tiếng Do Thái'),
('hi', N'Tiếng Hindi'),
('hif', N'Fiji Hindi'),
('hil', N'Tiếng Hiligaynon'),
('hit', N'Tiếng Hittite'),
('hmn', N'Tiếng Hmông'),
('ho', N'Tiếng Hiri Motu'),
('hr', N'Tiếng Croatia'),
('hsb', N'Tiếng Thượng Sorbia'),
('hsn', N'Xiang Chinese'),
('ht', N'Tiếng Haiti'),
('hu', N'Tiếng Hungary'),
('hup', N'Tiếng Hupa'),
('hy', N'Tiếng Armenia'),
('hz', N'Tiếng Herero'),
('ia', N'Tiếng Khoa Học Quốc Tế'),
('iba', N'Tiếng Iban'),
('ibb', N'Tiếng Ibibio'),
('id', N'Tiếng Indonesia'),
('ie', N'Tiếng Interlingue'),
('ig', N'Tiếng Igbo'),
('ii', N'Tiếng Di Tứ Xuyên'),
('ik', N'Tiếng Inupiaq'),
('ilo', N'Tiếng Iloko'),
('inh', N'Tiếng Ingush'),
('io', N'Tiếng Ido'),
('is', N'Tiếng Iceland'),
('it', N'Tiếng Ý'),
('iu', N'Tiếng Inuktitut'),
('izh', N'Ingrian'),
('ja', N'Tiếng Nhật'),
('jam', N'Jamaican Creole English'),
('jbo', N'Tiếng Lojban'),
('jgo', N'Tiếng Ngomba'),
('jmc', N'Tiếng Machame'),
('jpr', N'Tiếng Judeo-Ba Tư'),
('jrb', N'Tiếng Judeo-Ả Rập'),
('jut', N'Jutish'),
('jv', N'Tiếng Java'),
('ka', N'Tiếng Gruzia'),
('kaa', N'Tiếng Kara-Kalpak'),
('kab', N'Tiếng Kabyle'),
('kac', N'Tiếng Kachin'),
('kaj', N'Tiếng Jju'),
('kam', N'Tiếng Kamba'),
('kaw', N'Tiếng Kawi'),
('kbd', N'Tiếng Kabardian'),
('kbl', N'Tiếng Kanembu'),
('kcg', N'Tiếng Tyap'),
('kde', N'Tiếng Makonde'),
('kea', N'Tiếng Kabuverdianu'),
('ken', N'Kenyang'),
('kfo', N'Tiếng Koro'),
('kg', N'Tiếng Kongo'),
('kgp', N'Kaingang'),
('kha', N'Tiếng Khasi'),
('kho', N'Tiếng Khotan'),
('khq', N'Tiếng Koyra Chiini'),
('khw', N'Khowar'),
('ki', N'Tiếng Kikuyu'),
('kiu', N'Kirmanjki'),
('kj', N'Tiếng Kuanyama'),
('kk', N'Tiếng Kazakh'),
('kkj', N'Tiếng Kako'),
('kl', N'Tiếng Kalaallisut'),
('kln', N'Tiếng Kalenjin'),
('km', N'Tiếng Khơ-me'),
('kmb', N'Tiếng Kimbundu'),
('kn', N'Tiếng Kannada'),
('ko', N'Tiếng Hàn'),
('koi', N'Tiếng Komi-Permyak'),
('kok', N'Tiếng Konkani'),
('kos', N'Tiếng Kosrae'),
('kpe', N'Tiếng Kpelle'),
('kr', N'Tiếng Kanuri'),
('krc', N'Tiếng Karachay-Balkar'),
('kri', N'Krio'),
('krj', N'Kinaray-a'),
('krl', N'Tiếng Karelian'),
('kru', N'Tiếng Kurukh'),
('ks', N'Tiếng Kashmiri'),
('ksb', N'Tiếng Shambala'),
('ksf', N'Tiếng Bafia'),
('ksh', N'Tiếng Cologne'),
('ku', N'Tiếng Kurd'),
('kum', N'Tiếng Kumyk'),
('kut', N'Tiếng Kutenai'),
('kv', N'Tiếng Komi'),
('kw', N'Tiếng Cornwall'),
('ky', N'Tiếng Kyrgyz'),
('la', N'Tiếng La-tinh'),
('lad', N'Tiếng Ladino'),
('lag', N'Tiếng Langi'),
('lah', N'Tiếng Lahnda'),
('lam', N'Tiếng Lamba'),
('lb', N'Tiếng Luxembourg'),
('lez', N'Tiếng Lezghian'),
('lfn', N'Lingua Franca Nova'),
('lg', N'Tiếng Ganda'),
('li', N'Tiếng Limburg'),
('lij', N'Ligurian'),
('liv', N'Livonian'),
('lkt', N'Tiếng Lakota'),
('lmo', N'Lombard'),
('ln', N'Tiếng Lingala'),
('lo', N'Tiếng Lào'),
('lol', N'Tiếng Mongo'),
('loz', N'Tiếng Lozi'),
('lt', N'Tiếng Lít-va'),
('ltg', N'Latgalian'),
('lu', N'Tiếng Luba-Katanga'),
('lua', N'Tiếng Luba-Lulua'),
('lui', N'Tiếng Luiseno'),
('lun', N'Tiếng Lunda'),
('luo', N'Tiếng Luo'),
('lus', N'Tiếng Lushai'),
('luy', N'Tiếng Luyia'),
('lv', N'Tiếng Latvia'),
('lzh', N'Literary Chinese'),
('lzz', N'Laz'),
('mad', N'Tiếng Madura'),
('maf', N'Tiếng Mafa'),
('mag', N'Tiếng Magahi'),
('mai', N'Tiếng Maithili'),
('mak', N'Tiếng Makasar'),
('man', N'Tiếng Mandingo'),
('mas', N'Tiếng Masai'),
('mde', N'Tiếng Maba'),
('mdf', N'Tiếng Moksha'),
('mdr', N'Tiếng Mandar'),
('men', N'Tiếng Mende'),
('mer', N'Tiếng Meru'),
('mfe', N'Tiếng Morisyen'),
('mg', N'Tiếng Malagasy'),
('mga', N'Tiếng Ai-len Trung cổ'),
('mgh', N'Tiếng Makhuwa-Meetto'),
('mgo', N'Tiếng Meta’'),
('mh', N'Tiếng Marshall'),
('mi', N'Tiếng Maori'),
('mic', N'Tiếng Micmac'),
('min', N'Tiếng Minangkabau'),
('mk', N'Tiếng Macedonia'),
('ml', N'Tiếng Malayalam'),
('mn', N'Tiếng Mông Cổ'),
('mnc', N'Tiếng Manchu'),
('mni', N'Tiếng Manipuri'),
('moh', N'Tiếng Mohawk'),
('mos', N'Tiếng Mossi'),
('mr', N'Tiếng Marathi'),
('mrj', N'Western Mari'),
('ms', N'Tiếng Malaysia'),
('mt', N'Tiếng Malt'),
('mua', N'Tiếng Mundang'),
('mul', N'Nhiều Ngôn ngữ'),
('mus', N'Tiếng Creek'),
('mwl', N'Tiếng Miranda'),
('mwr', N'Tiếng Marwari'),
('mwv', N'Mentawai'),
('my', N'Tiếng Miến Điện'),
('mye', N'Tiếng Myene'),
('myv', N'Tiếng Erzya'),
('mzn', N'Mazanderani'),
('na', N'Tiếng Nauru'),
('nan', N'Min Nan Chinese'),
('nap', N'Tiếng Napoli'),
('naq', N'Tiếng Nama'),
('nb', N'Tiếng Na Uy (Bokmål)'),
('nd', N'Tiếng Ndebele Miền Bắc'),
('nds', N'Tiếng Hạ Giéc-man'),
('ne', N'Tiếng Nepal'),
('new', N'Tiếng Newari'),
('ng', N'Tiếng Ndonga'),
('nia', N'Tiếng Nias'),
('niu', N'Tiếng Niuean'),
('njo', N'Ao Naga'),
('nl', N'Tiếng Hà Lan'),
('nl_BE', N'Tiếng Flemish'),
('nmg', N'Tiếng Kwasio'),
('nn', N'Tiếng Na Uy (Nynorsk)'),
('nnh', N'Tiếng Ngiemboon'),
('no', N'Tiếng Na Uy'),
('nog', N'Tiếng Nogai'),
('non', N'Tiếng Na Uy cổ'),
('nov', N'Novial'),
('nqo', N'Tiếng N’Ko'),
('nr', N'Tiếng Ndebele Miền Nam'),
('nso', N'Bắc Sotho'),
('nus', N'Tiếng Nuer'),
('nv', N'Tiếng Navajo'),
('nwc', N'Tiếng Newari Cổ điển'),
('ny', N'Tiếng Nyanja'),
('nym', N'Tiếng Nyamwezi'),
('nyn', N'Tiếng Nyankole'),
('nyo', N'Tiếng Nyoro'),
('nzi', N'Tiếng Nzima'),
('oc', N'Tiếng Occitan'),
('oj', N'Tiếng Ojibwa'),
('om', N'Tiếng Oromo'),
('or', N'Tiếng Oriya'),
('os', N'Tiếng Ossetic'),
('osa', N'Tiếng Osage'),
('ota', N'Tiếng Thổ Nhĩ Kỳ Ottoman'),
('pa', N'Tiếng Punjab'),
('pag', N'Tiếng Pangasinan'),
('pal', N'Tiếng Pahlavi'),
('pam', N'Tiếng Pampanga'),
('pap', N'Tiếng Papiamento'),
('pau', N'Tiếng Palauan'),
('pcd', N'Picard'),
('pdc', N'Pennsylvania German'),
('pdt', N'Plautdietsch'),
('peo', N'Tiếng Ba Tư cổ'),
('pfl', N'Palatine German'),
('phn', N'Tiếng Phoenicia'),
('pi', N'Tiếng Pali'),
('pl', N'Tiếng Ba Lan'),
('pms', N'Piedmontese'),
('pnt', N'Pontic'),
('pon', N'Tiếng Pohnpeian'),
('prg', N'Prussian'),
('pro', N'Tiếng Provençal cổ'),
('ps', N'Tiếng Pashto'),
('pt', N'Tiếng Bồ Đào Nha'),
('pt_BR', N'Tiếng Bồ Đào Nha (Braxin)'),
('pt_PT', N'European Portuguese'),
('qu', N'Tiếng Quechua'),
('quc', N'Tiếng Kʼicheʼ'),
('qug', N'Chimborazo Highland Quichua'),
('raj', N'Tiếng Rajasthani'),
('rap', N'Tiếng Rapanui'),
('rar', N'Tiếng Rarotongan'),
('rgn', N'Romagnol'),
('rif', N'Riffian'),
('rm', N'Tiếng Romansh'),
('rn', N'Tiếng Rundi'),
('ro', N'Tiếng Rumani'),
('rof', N'Tiếng Rombo'),
('rom', N'Tiếng Romany'),
('root', N'Tiếng Root'),
('ro_MD', N'Tiếng Moldova'),
('rtm', N'Rotuman'),
('ru', N'Tiếng Nga'),
('rue', N'Rusyn'),
('rug', N'Roviana'),
('rup', N'Tiếng Aromania'),
('rw', N'Tiếng Kinyarwanda'),
('rwk', N'Tiếng Rwa'),
('sa', N'Tiếng Phạn'),
('sad', N'Tiếng Sandawe'),
('sah', N'Tiếng Sakha'),
('sam', N'Tiếng Samaritan Aramaic'),
('saq', N'Tiếng Samburu'),
('sas', N'Tiếng Sasak'),
('sat', N'Tiếng Santali'),
('saz', N'Saurashtra'),
('sba', N'Tiếng Ngambay'),
('sbp', N'Tiếng Sangu'),
('sc', N'Tiếng Sardinia'),
('scn', N'Tiếng Sicilia'),
('sco', N'Tiếng Scots'),
('sd', N'Tiếng Sindhi'),
('sdc', N'Sassarese Sardinian'),
('se', N'Tiếng Sami Miền Bắc'),
('see', N'Tiếng Seneca'),
('seh', N'Tiếng Sena'),
('sei', N'Seri'),
('sel', N'Tiếng Selkup'),
('ses', N'Tiếng Koyraboro Senni'),
('sg', N'Tiếng Sango'),
('sga', N'Tiếng Ai-len cổ'),
('sgs', N'Samogitian'),
('sh', N'Tiếng Xéc bi - Croatia'),
('shi', N'Tiếng Tachelhit'),
('shn', N'Tiếng Shan'),
('shu', N'Tiếng Ả-Rập Chad'),
('si', N'Tiếng Sinhala'),
('sid', N'Tiếng Sidamo'),
('sk', N'Tiếng Slovak'),
('sl', N'Tiếng Slovenia'),
('sli', N'Lower Silesian'),
('sly', N'Selayar'),
('sm', N'Tiếng Samoa'),
('sma', N'TIếng Sami Miền Nam'),
('smj', N'Tiếng Lule Sami'),
('smn', N'Tiếng Inari Sami'),
('sms', N'Tiếng Skolt Sami'),
('sn', N'Tiếng Shona'),
('snk', N'Tiếng Soninke'),
('so', N'Tiếng Somali'),
('sog', N'Tiếng Sogdien'),
('sq', N'Tiếng An-ba-ni'),
('sr', N'Tiếng Serbia'),
('srn', N'Tiếng Sranan Tongo'),
('srr', N'Tiếng Serer'),
('ss', N'Tiếng Swati'),
('ssy', N'Tiếng Saho'),
('st', N'Tiếng Sesotho'),
('stq', N'Saterland Frisian'),
('su', N'Tiếng Sudan'),
('suk', N'Tiếng Sukuma'),
('sus', N'Tiếng Susu'),
('sux', N'Tiếng Sumeria'),
('sv', N'Tiếng Thụy Điển'),
('sw', N'Tiếng Swahili'),
('swb', N'Tiếng Cômo'),
('swc', N'Tiếng Swahili Congo'),
('syc', N'Tiếng Syria Cổ điển'),
('syr', N'Tiếng Syriac'),
('szl', N'Silesian'),
('ta', N'Tiếng Tamil'),
('tcy', N'Tulu'),
('te', N'Tiếng Telugu'),
('tem', N'Tiếng Timne'),
('teo', N'Tiếng Teso'),
('ter', N'Tiếng Tereno'),
('tet', N'Tetum'),
('tg', N'Tiếng Tajik'),
('th', N'Tiếng Thái'),
('ti', N'Tiếng Tigrigya'),
('tig', N'Tiếng Tigre'),
('tiv', N'Tiếng Tiv'),
('tk', N'Tiếng Turk'),
('tkl', N'Tiếng Tokelau'),
('tkr', N'Tsakhur'),
('tl', N'Tiếng Tagalog'),
('tlh', N'Tiếng Klingon'),
('tli', N'Tiếng Tlingit'),
('tly', N'Talysh'),
('tmh', N'Tiếng Tamashek'),
('tn', N'Tiếng Tswana'),
('to', N'Tiếng Tonga'),
('tog', N'Tiếng Nyasa Tonga'),
('tpi', N'Tiếng Tok Pisin'),
('tr', N'Tiếng Thổ Nhĩ Kỳ'),
('tru', N'Turoyo'),
('trv', N'Tiếng Taroko'),
('ts', N'Tiếng Tsonga'),
('tsd', N'Tsakonian'),
('tsi', N'Tiếng Tsimshian'),
('tt', N'Tiếng Tatar'),
('ttt', N'Muslim Tat'),
('tum', N'Tiếng Tumbuka'),
('tvl', N'Tiếng Tuvalu'),
('tw', N'Tiếng Twi'),
('twq', N'Tiếng Tasawaq'),
('ty', N'Tiếng Tahiti'),
('tyv', N'Tiếng Tuvinian'),
('tzm', N'Tiếng Tamazight Miền Trung Ma-rốc'),
('udm', N'Tiếng Udmurt'),
('ug', N'Tiếng Uyghur'),
('uga', N'Tiếng Ugaritic'),
('uk', N'Tiếng Ucraina'),
('umb', N'Tiếng Umbundu'),
('und', N'Ngôn ngữ không xác định'),
('ur', N'Tiếng Uđu'),
('uz', N'Tiếng Uzbek'),
('vai', N'Tiếng Vai'),
('ve', N'Tiếng Venda'),
('vec', N'Venetian'),
('vep', N'Veps'),
('vi', N'Tiếng Việt'),
('vls', N'West Flemish'),
('vmf', N'Main-Franconian'),
('vo', N'Tiếng Volapük'),
('vot', N'Tiếng Votic'),
('vro', N'Võro'),
('vun', N'Tiếng Vunjo'),
('wa', N'Tiếng Walloon'),
('wae', N'Tiếng Walser'),
('wal', N'Tiếng Walamo'),
('war', N'Tiếng Waray'),
('was', N'Tiếng Washo'),
('wbp', N'Warlpiri'),
('wo', N'Tiếng Wolof'),
('wuu', N'Wu Chinese'),
('xal', N'Tiếng Kalmyk'),
('xh', N'Tiếng Xhosa'),
('xmf', N'Mingrelian'),
('xog', N'Tiếng Soga'),
('yao', N'Tiếng Yao'),
('yap', N'Tiếng Yap'),
('yav', N'Tiếng Yangben'),
('ybb', N'Tiếng Yemba'),
('yi', N'Tiếng Y-đit'),
('yo', N'Tiếng Yoruba'),
('yrl', N'Nheengatu'),
('yue', N'Tiếng Quảng Đông'),
('za', N'Tiếng Zhuang'),
('zap', N'Tiếng Zapotec'),
('zbl', N'Ký hiệu Blissymbols'),
('zea', N'Zeelandic'),
('zen', N'Tiếng Zenaga'),
('zgh', N'Tiếng Tamazight Chuẩn của Ma-rốc'),
('zh', N'Tiếng Trung'),
('zh_Hans', N'Simplified Chinese'),
('zh_Hant', N'Traditional Chinese'),
('zu', N'Tiếng Zulu'),
('zun', N'Tiếng Zuni'),
('zza', N'Tiếng Zaza');
GO

CREATE TABLE Categories
(
	CategoryID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	CategoryName NVARCHAR(64),
	ParentID INT,
	Active BIT DEFAULT 1
)
GO

INSERT INTO Categories (CategoryName, ParentID) VALUES
(N'Chính trị – Pháp luật', 0),
(N'Khoa học công nghệ – Kinh tế', 0),
(N'Văn học nghệ thuật', 0),
(N'Văn hóa xã hội – Lịch sử', 0),
(N'Giáo trình', 0),
(N'Truyện, tiểu thuyết', 0),
(N'Tâm lý, tâm linh, tôn giáo', 0),
(N'Sách thiếu nhi', 0)
GO

CREATE TABLE Authors
(
	AuthorID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	AuthorName NVARCHAR(64),
	Contact NTEXT
)
GO

INSERT INTO Authors (AuthorName, Contact) VALUES
(N'Aoyama Gosho', N'Đang cập nhật'),
(N'Nguyễn Nhật Ánh', N'Đang cập nhật'),
(N'Author Conan Doyle', N'Tác giả Anh'),
(N'Shinkai Makoto', N'Tác giả Nhật'),
(N'Tite Kubo', N'Đang cập nhật'),
(N'Tô Hoài', N'Đang cập nhật'),
(N'Eiichiro Oda', N'Đang cập nhật'),
(N'ONE', N'Đang cập nhật'),
(N'Murata', N'Đang cập nhật'),
(N'Gege Akutami', N'Đang cập nhật'),
(N'Obata', N'Đang cập nhật'),
(N'Masashi Kisimoto', N'Đang cập nhật'),
(N'Fujiko', N'Đang cập nhật')

GO

CREATE TABLE Publishes
(
	PublishID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	PublishName NVARCHAR(64),
	Phone VARCHAR(11),
	Address NVARCHAR(255),
	Fax VARCHAR(11)
)
GO

INSERT INTO Publishes (PublishName, Phone, Address, Fax) VALUES 
(N'Kim Đồng', '02839390465', N'TP. Hồ Chí Minh', ''),
(N'Trẻ', '02893316289', N'TP. Hồ Chí Minh', ''),
(N'IPM', '0333193979', N'110 Nguyễn Ngọc Nại, Hà Nội', ''),
(N'Đồng Nai', '0933109009', N'TP. Biên Hoà, Đồng Nai', '')
GO

CREATE TABLE Suppliers
(
	SupplierID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	SupplierName NVARCHAR(64),
	Phone VARCHAR(11),
	Address NVARCHAR(255),
	Fax VARCHAR(11)
)
GO

INSERT INTO Suppliers (SupplierName, Phone, Address, Fax) VALUES 
(N'Fasaha', '0987654321', N'TP. Hồ Chí Minh', '')
GO

CREATE TABLE Books
(
	ISBN VARCHAR(13) NOT NULL PRIMARY KEY,
	BookTitle NVARCHAR(255),
	Description NTEXT,
	PublishYear INT,
	Weight INT,
	Size VARCHAR(11),
	PageNumber INT,
	Thumbnail NVARCHAR(255),
	LanguageID VARCHAR(8),
	Price INT,
	QuantitySold INT,
	InventoryNumber INT,
	CategoryID INT,
	PublishID INT,

	FOREIGN KEY (LanguageID) REFERENCES Languages (LanguageID),
	FOREIGN KEY (CategoryID) REFERENCES Categories (CategoryID),
	FOREIGN KEY (PublishID) REFERENCES Publishes (PublishID),
)
GO

INSERT INTO Books VALUES
('9784041046593', N'Your Name', N'Truyện ngắn', 2016, 0, '130x176', 288, N'/assets/img/books/your-name.jpg', 'vi', 60000, 100, 100, 6, 3),
('9786042212840', N'Chú Thuật Hồi Chiến Tập 0', N'Truyện ngắn', 2021, 0, '117x176', 184, N'/assets/img/books/chu-thuat-hoi-chien-0.jpg', 'vi', 30000, 100, 100, 6, 1),
('9786042268127', N'Chú Thuật Hồi Chiến Tập 1', N'Truyện ngắn', 2022, 0, '117x176', 184, N'/assets/img/books/chu-thuat-hoi-chien-1.jpg', 'vi', 30000, 100, 100, 6, 1),
('9786042212842', N'Chú Thuật Hồi Chiến Tập 2', N'Truyện ngắn', 2021, 0, '117x176', 184, N'/assets/img/books/chu-thuat-hoi-chien-2.jpg', 'vi', 30000, 100, 100, 6, 1),
('9786042234252', N'Thám Tử Lừng Danh Conan - Tập 99', N'Truyện ngắn', 2022, 200, '176x113', 184, N'/assets/img/books/conan-tap-99.jpg', 'vi', 20000, 100, 100, 6, 1),
('9784088802206', N'Naruto tập 72', N'Truyện ngắn', 2021, 0, '117x176', 288, N'/assets/img/books/naruto-vol-72.jpg', 'vi', 22000, 100, 100, 6, 3),
('9786042212847', N'Doraemon dài - Tập 14: Nobita và ba chàng hiệp sĩ mộng mơ', N'Truyện dài', 2021, 0, '130x190', 189, N'/assets/img/books/doraemon-vol-14.jpg', 'vi', 18000, 100, 100, 6, 1),
('9786042212831', N'Death Note Tập 1', N'Truyện ngắn', 2020, 0, '117x176', 184, N'/assets/img/books/death-note-1.jpg', 'vi', 35000, 100, 100, 6, 1),
('9786042212811', N'One Punch Man Tập 1', N'Truyện ngắn', 2018, 0, '117x176', 184, N'/assets/img/books/opm-1.jpg', 'vi', 18000, 100, 100, 6, 1),
('9786042212819', N'One Punch Man Tập 9', N'Truyện ngắn', 2018, 0, '117x176', 184, N'/assets/img/books/opm-9.jpg', 'vi', 18000, 100, 100, 6, 1)

GO

CREATE TABLE Images
(
	ImageID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	ImagePath NVARCHAR(255),
	ISBN VARCHAR(13) NOT NULL,

	FOREIGN KEY (ISBN) REFERENCES Books (ISBN)
)
GO

CREATE TABLE Orders
(
	OrderID VARCHAR(10) PRIMARY KEY,
	TotalMoney INT,
	TotalRevenue INT,
	Status BIT, -- 0: chưa giao -- 1: đã giao
	PaymentDate DATETIME,
	CreatedAt DATETIME DEFAULT GETDATE(),
	Username NVARCHAR(64) NOT NULL,

	FOREIGN KEY (Username) REFERENCES Users (Username)
)
GO

CREATE TABLE OrderDetails
(
	OrderDetailsID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	ISBN VARCHAR(13) NOT NULL,
	OrderID VARCHAR(10),
	Amount INT,
	CreatedAt DATETIME DEFAULT GETDATE()

	FOREIGN KEY (ISBN) REFERENCES Books (ISBN),
	FOREIGN KEY (OrderID) REFERENCES Orders (OrderID),
)
GO

CREATE TABLE Carts
(
	ISBN VARCHAR(13) NOT NULL,
	Username NVARCHAR(64) NOT NULL,
	Amount INT DEFAULT 1,
	UpdatedAt DATETIME DEFAULT GETDATE(),

	PRIMARY KEY (ISBN, Username),
	FOREIGN KEY (ISBN) REFERENCES Books (ISBN),
	FOREIGN KEY (Username) REFERENCES Users (Username),
)
GO

CREATE TABLE Composers
(
	ISBN VARCHAR(13) NOT NULL,
	AuthorID INT NOT NULL,
	Role NVARCHAR(20)

	PRIMARY KEY (ISBN, AuthorID),
	FOREIGN KEY (ISBN) REFERENCES Books (ISBN),
	FOREIGN KEY (AuthorID) REFERENCES Authors (AuthorID),
)
GO

INSERT INTO Composers VALUES
('9784041046593', 4, N'Chủ biên'),
('9786042268127', 10, N'Chủ biên'),
('9786042234252', 1, N'Chủ biên'),
('9784088802206', 12, N'Chủ biên'),
('9786042212847', 13, N'Chủ biên'),
('9786042212840', 10, N'Chủ biên'),
('9786042212842', 10, N'Chủ biên'),
('9786042212831', 7, N'Chủ biên'),
('9786042268127', 11, N'Chủ biên'),
('9786042212811', 8, N'Chủ biên'),
('9786042212811', 9, N'Tác giả phụ'),
('9786042212819', 8, N'Chủ biên'),
('9786042212819', 9, N'Tác giả phụ')

GO

CREATE TABLE Rating
(
	RatingID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	ISBN VARCHAR(13) NOT NULL,
	Username NVARCHAR(64) NOT NULL,
	Point INT,
	CreatedAt DATETIME DEFAULT GETDATE(),
	UpdatedAt DATETIME DEFAULT GETDATE(),

	FOREIGN KEY (ISBN) REFERENCES Books (ISBN),
	FOREIGN KEY (Username) REFERENCES Users (Username),
)
GO

CREATE TABLE Receipts
(
	ISBN VARCHAR(13) NOT NULL,
	SupplierID INT NOT NULL,
	Amount INT,
	Price INT,
	CreatedAt DATETIME DEFAULT GETDATE(),

	PRIMARY KEY (ISBN, SupplierID),
	FOREIGN KEY (ISBN) REFERENCES Books (ISBN),
	FOREIGN KEY (SupplierID) REFERENCES Suppliers (SupplierID),
)
GO

CREATE TABLE Vouchers
(
	VoucherID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Name NVARCHAR(255),
	Discount INT,
	StartTime DATETIME,
	EndTime DATETIME,
	UsedStatus BIT, -- 0: chưa dùng, 1: đã dùng
	Username NVARCHAR(64),

	FOREIGN KEY (Username) REFERENCES Users (Username),
)
GO

CREATE TABLE Sliders
(
	SliderID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	SliderName NVARCHAR(255),
	Description NVARCHAR(255),
	Thumbnail NVARCHAR(255),
	Status BIT
)
GO

INSERT INTO Sliders (SliderName, Description, Thumbnail, Status) VALUES 
(N'Slider 1', N'Mô tả slide 1', '/assets/img/sliders/slider-1.png', 1),
(N'Slider 2', N'Mô tả slide 2', '/assets/img/sliders/slider-2.png', 1),
(N'Slider 3', N'Mô tả slide 3', '/assets/img/sliders/slider-3.jpg', 1),
(N'Slider 4', N'Mô tả slide 4', '/assets/img/sliders/slider-4.jpg', 1)
GO

CREATE TABLE Comments
(
	CommentID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	ISBN VARCHAR(13) NOT NULL,
	Username NVARCHAR(64),
	Description NTEXT,
	Active BIT DEFAULT 0,
	CreatedAt DATE DEFAULT GETDATE(),

	FOREIGN KEY (ISBN) REFERENCES Books (ISBN),
	FOREIGN KEY (Username) REFERENCES Users (Username),
)
GO