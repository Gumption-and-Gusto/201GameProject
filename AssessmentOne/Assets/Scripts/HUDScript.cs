using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class HUDScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI pilotText;
    [SerializeField]
    CanvasGroup fadeIn;
    string[] fnames = { "LIAM", "NOAH", "OLIVER", "ELIJAH", "JAMES", "WILLIAM", "BENJAMIN", "LUCAS", "HENRY", "THEODORE", "JACK", "LEVI", "ALEXANDER", "JACKSON", "MATEO", "DANIEL", "MICHAEL", "MASON", "SEBASTIAN", "ETHAN", "LOGAN", "OWEN", "SAMUEL", "JACOB", "ASHER", "AIDEN", "JOHN", "JOSEPH", "WYATT", "DAVID", "LEO", "LUKE", "JULIAN", "HUDSON", "GRAYSON", "MATTHEW", "EZRA", "GABRIEL", "CARTER", "ISAAC", "JAYDEN", "LUCA", "ANTHONY", "DYLAN", "LINCOLN", "THOMAS", "MAVERICK", "ELIAS", "JOSIAH", "CHARLES", "CALEB", "CHRISTOPHER", "EZEKIEL", "MILES", "JAXON", "ISAIAH", "ANDREW", "JOSHUA", "NATHAN", "NOLAN", "ADRIAN", "CAMERON", "SANTIAGO", "ELI", "AARON", "RYAN", "ANGEL", "COOPER", "WAYLON", "EASTON", "KAI", "CHRISTIAN", "LANDON", "COLTON", "ROMAN", "AXEL", "BROOKS", "JONATHAN", "ROBERT", "JAMESON", "IAN", "EVERETT", "GREYSON", "WESLEY", "JEREMIAH", "HUNTER", "LEONARDO", "JORDAN", "JOSE", "BENNETT", "SILAS", "NICHOLAS", "PARKER", "BEAU", "WESTON", "AUSTIN", "CONNOR", "CARSON", "DOMINIC", "XAVIER", "JAXSON", "JACE", "EMMETT", "ADAM", "DECLAN", "ROWAN", "MICAH", "KAYDEN", "GAEL", "RIVER", "RYDER", "KINGSTON", "DAMIAN", "SAWYER", "LUKA", "EVAN", "VINCENT", "LEGEND", "MYLES", "HARRISON", "AUGUST", "BRYSON", "AMIR", "GIOVANNI", "CHASE", "DIEGO", "MILO", "JASPER", "WALKER", "JASON", "BRAYDEN", "COLE", "NATHANIEL", "GEORGE", "LORENZO", "ZION", "LUIS", "ARCHER", "ENZO", "JONAH", "THIAGO", "THEO", "AYDEN", "ZACHARY", "CALVIN", "BRAXTON", "ASHTON", "RHETT", "ATLAS", "JUDE", "BENTLEY", "CARLOS", "RYKER", "ADRIEL", "ARTHUR", "ACE", "TYLER", "JAYCE", "MAX", "ELLIOT", "GRAHAM", "KAIDEN", "MAXWELL", "JUAN", "DEAN", "MATTEO", "MALACHI", "IVAN", "ELLIOTT", "JESUS", "EMILIANO", "MESSIAH", "GAVIN", "MADDOX", "CAMDEN", "HAYDEN", "LEON", "ANTONIO", "JUSTIN", "TUCKER", "BRANDON", "KEVIN", "JUDAH", "FINN", "KING", "BRODY", "XANDER", "NICOLAS", "CHARLIE", "ARLO", "EMMANUEL", "BARRETT", "FELIX", "ALEX", "MIGUEL", "ABEL", "ALAN", "BECKETT", "AMARI", "KARTER", "TIMOTHY", "ABRAHAM", "JESSE", "ZAYDEN", "BLAKE", "ALEJANDRO", "DAWSON", "TRISTAN", "VICTOR", "AVERY", "JOEL", "GRANT", "ERIC", "PATRICK", "PETER", "RICHARD", "EDWARD", "ANDRES", "EMILIO", "COLT", "KNOX", "BECKHAM", "ADONIS", "KYRIE", "MATIAS", "OSCAR", "LUKAS", "MARCUS", "HAYES", "CADEN", "REMINGTON", "GRIFFIN", "NASH", "ISRAEL", "STEVEN", "HOLDEN", "RAFAEL", "ZANE", "JEREMY", "KASH", "PRESTON", "KYLER", "JAX", "JETT", "KALEB", "RILEY", "SIMON", "PHOENIX", "JAVIER", "BRYCE", "LOUIS", "MARK", "CASH", "LENNOX", "PAXTON", "MALAKAI", "PAUL", "KENNETH", "NICO", "KADEN", "LANE", "KAIRO", "MAXIMUS", "OMAR", "FINLEY", "ATTICUS", "CREW", "BRANTLEY", "COLIN", "DALLAS", "WALTER", "BRADY", "CALLUM", "RONAN", "HENDRIX", "JORGE", "TOBIAS", "CLAYTON", "EMERSON", "DAMIEN", "ZAYN", "MALCOLM", "KAYSON", "BODHI", "BRYAN", "AIDAN", "COHEN", "BRIAN", "CAYDEN", "ANDRE", "NIKO", "MAXIMILIANO", "ZANDER", "KHALIL", "RORY", "FRANCISCO", "CRUZ", "KOBE", "REID", "DAXTON", "DEREK", "MARTIN", "JENSEN", "KARSON", "TATE", "MUHAMMAD", "JADEN", "JOAQUIN", "JOSUE", "GIDEON", "DANTE", "CODY", "BRADLEY", "ORION", "SPENCER", "ANGELO", "ERICK", "JAYLEN", "JULIUS", "MANUEL", "ELLIS", "COLSON", "CAIRO", "GUNNER", "WADE", "CHANCE", "ODIN", "ANDERSON", "KANE", "RAYMOND", "CRISTIAN", "AZIEL", "PRINCE", "EZEQUIEL", "JAKE", "OTTO", "EDUARDO", "RYLAN", "ALI", "CADE", "STEPHEN", "ARI", "KAMERON", "DAKOTA", "WARREN", "RICARDO", "KILLIAN", "MARIO", "ROMEO", "CYRUS", "ISMAEL", "RUSSELL", "TYSON", "EDWIN", "DESMOND", "NASIR", "REMY", "TANNER", "FERNANDO", "HECTOR", "TITUS", "LAWSON", "SEAN", "KYLE", "ELIAN", "CORBIN", "BOWEN", "WILDER", "ARMANI", "ROYAL", "STETSON", "BRIGGS", "SULLIVAN", "LEONEL", "CALLAN", "FINNEGAN", "JAY", "ZAYNE", "MARSHALL", "KADE", "TRAVIS", "STERLING", "RAIDEN", "SERGIO", "TATUM", "CESAR", "ZYAIRE", "MILAN", "DEVIN", "GIANNI", "KAMARI", "ROYCE", "MALIK", "JARED", "FRANKLIN", "CLARK", "NOEL", "MARCO", "ARCHIE", "APOLLO", "PABLO", "GARRETT", "OAKLEY", "MEMPHIS", "QUINN", "ONYX", "ALIJAH", "BAYLOR", "EDGAR", "NEHEMIAH", "WINSTON", "MAJOR", "RHYS", "FORREST", "JAIDEN", "REED", "SANTINO", "TROY", "CAIDEN", "HARVEY", "COLLIN", "SOLOMON", "DONOVAN", "DAMON", "JEFFREY", "KASON", "SAGE", "GRADY", "KENDRICK", "LELAND", "LUCIANO", "PEDRO", "HANK", "HUGO", "ESTEBAN", "JOHNNY", "KASHTON", "RONIN", "FORD", "MATHIAS", "PORTER", "ERIK", "JOHNATHAN", "FRANK", "TRIPP", "CASEY", "FABIAN", "LEONIDAS", "BAKER", "MATTHIAS", "PHILIP", "JAYCEON", "KIAN", "SAINT", "IBRAHIM", "JAXTON", "AUGUSTUS", "CALLEN", "TREVOR", "RUBEN", "ADAN", "CONOR", "DAX", "BRAYLEN", "KAISON", "FRANCIS", "KYSON", "ANDY", "LUCCA", "MACK", "PEYTON", "ALEXIS", "DEACON", "KASEN", "KAMDEN", "FREDERICK", "PRINCETON", "BRAYLON", "WELLS", "NIKOLAI", "IKER", "BO", "DOMINICK", "MOSHE", "CASSIUS", "GREGORY", "LEWIS", "KIERAN", "ISAIAS", "SETH", "MARCOS", "OMARI", "SHANE", "KEEGAN", "JASE", "ASA", "SONNY", "URIEL", "PIERCE", "JASIAH", "EDEN", "ROCCO", "BANKS", "CANNON", "DENVER", "ZAIDEN", "ROBERTO", "SHAWN", "DREW", "EMANUEL", "KOLTON", "AYAAN", "ARES", "CONNER", "JALEN", "ALONZO", "ENRIQUE", "DALTON", "MOSES", "KODA", "BODIE", "JAMISON", "PHILLIP", "ZAIRE", "JONAS", "KYLO", "MOISES", "SHEPHERD", "ALLEN", "KENZO", "MOHAMED", "KEANU", "DEXTER", "CONRAD", "BRUCE", "SYLAS", "SOREN", "RAPHAEL", "ROWEN", "GUNNAR", "SUTTON", "QUENTIN", "JAZIEL", "EMMITT", "MAKAI", "KOA", "MAXIMILIAN", "BRIXTON", "DARIEL", "ZACHARIAH", "ROY", "ARMANDO", "COREY", "SAUL", "IZAIAH", "DANNY", "DAVIS", "RIDGE", "YUSUF", "ARIEL", "VALENTINO", "JAYSON", "RONALD", "ALBERT", "GERARDO", "RYLAND", "DORIAN", "DRAKE", "GAGE", "RODRIGO", "HEZEKIAH", "KYLAN", "BOONE", "LEDGER", "SANTANA", "JAMARI", "JAMIR", "LAWRENCE", "REECE", "KAYSEN", "SHILOH", "ARJUN", "MARCELO", "ABRAM", "BENSON", "HUXLEY", "NIKOLAS", "ZAIN", "KOHEN", "SAMSON", "MILLER", "DONALD", "FINNLEY", "KANNON", "LUCIAN", "WATSON", "KEITH", "WESTIN", "TADEO", "SINCERE", "BOSTON", "AXTON", "AMOS", "CHANDLER", "LEANDRO", "RAUL", "SCOTT", "REIGN", "ALESSANDRO", "CAMILO", "DERRICK", "MORGAN", "JULIO", "CLAY", "EDISON", "JAIME", "AUGUSTINE", "JULIEN", "ZEKE", "MARVIN", "BELLAMY", "LANDEN", "DUSTIN", "JAMIE", "KREW", "KYREE", "COLTER", "JOHAN", "HOUSTON", "LAYTON", "QUINCY", "CASE", "ATREUS", "CAYSON", "AARAV", "DARIUS", "HARLAN", "JUSTICE", "ABDIEL", "LAYNE", "RAYLAN", "ARTURO", "TAYLOR", "ANAKIN", "ANDER", "HAMZA", "OTIS", "AZARIAH", "LEONARD", "COLBY", "DUKE", "FLYNN", "TREY", "GUSTAVO", "FLETCHER", "ISSAC", "SAM", "TRENTON", "CALLAHAN", "CHRIS", "MOHAMMAD", "RAYAN", "LIONEL", "BRUNO", "JAXXON", "ZAID", "BRYCEN", "ROLAND", "DILLON", "LENNON", "AMBROSE", "RIO", "MAC", "AHMED", "SAMIR", "YOSEF", "TRU", "CREED", "TONY", "ALDEN", "ADEN", "ALEC", "CARMELO", "DARIO", "MARCEL", "ROGER", "TY", "AHMAD", "EMIR", "LANDYN", "SKYLER", "MOHAMMED", "DENNIS", "KAREEM", "NIXON", "REX", "URIAH", "LEE", "LOUIE", "RAYDEN", "REESE", "ALBERTO", "CASON", "QUINTON", "KINGSLEY", "CHAIM", "ALFREDO", "MAURICIO", "CASPIAN", "LEGACY", "OCEAN", "OZZY", "BRIAR", "WILSON", "FOREST", "GREY", "JOZIAH", "SALEM", "NEIL", "REMI", "BRIDGER", "HARRY", "JEFFERSON", "LACHLAN", "NELSON", "CASEN", "SALVADOR", "MAGNUS", "TOMMY", "MARCELLUS", "MAXIMO", "JERRY", "CLYDE", "ARON", "KEATON", "ELIAM", "LIAN", "TRACE", "DOUGLAS", "JUNIOR", "TITAN", "CULLEN", "CILLIAN", "MUSA", "MYLO", "HUGH", "TOMAS", "VINCENZO", "WESTLEY", "LANGSTON", "BYRON", "KIAAN", "LOYAL", "ORLANDO", "KYRO", "AMIAS", "AMIRI", "JIMMY", "VICENTE", "KHARI", "BRENDAN", "REY", "BEN", "EMERY", "ZYAIR", "BJORN", "EVANDER", "RAMON", "ALVIN", "RICKY", "JAGGER", "BROCK", "DAKARI", "EDDIE", "BLAZE", "GATLIN", "ALONSO", "CURTIS", "KYLIAN", "NATHANAEL", "DEVON", "WAYNE", "ZAKAI", "MATHEW", "ROME", "RIGGS", "ARYAN", "AVI", "HASSAN", "LOCHLAN", "STANLEY", "DASH", "KAISER", "BENICIO", "BRYANT", "TALON", "ROHAN", "WESSON", "JOE", "NOE", "MELVIN", "VIHAAN", "ZAYD", "DARREN", "ENOCH", "MITCHELL", "JEDIDIAH", "BRODIE", "CASTIEL", "IRA", "LANCE", "GUILLERMO", "THATCHER", "ERMIAS", "MISAEL", "JAKARI", "EMORY", "MCCOY", "RUDY", "THADDEUS", "VALENTIN", "YEHUDA", "BODE", "MADDEN", "KASE", "BEAR", "BODEN", "JIRAIYA", "MAURICE", "ALVARO", "AMEER", "DEMETRIUS", "ELISEO", "KABIR", "KELLAN", "ALLAN", "AZRAEL", "CALUM", "NIKLAUS", "RAY", "DAMARI", "ELIO", "JON", "LEIGHTON", "AXL", "DANE", "EITHAN", "EUGENE", "KENJI", "JAKOB", "COLTEN", "ELIEL", "NOVA", "SANTOS", "ZAHIR", "IDRIS", "ISHAAN", "KOLE", "KORBIN", "SEVEN", "ALARIC", "KELLEN", "BRONSON", "FRANCO", "WES", "LARRY", "MEKHI", "JAMAL", "DILAN", "ELISHA", "BRENNAN", "KACE", "VAN", "FELIPE", "FISHER", "CAL", "DIOR", "JUDSON", "ALFONSO", "DEANDRE", "ROCKY", "HENRIK", "REUBEN", "ANDERS", "ARIAN", "DAMIR", "JACOBY", "KHALID", "KYE", "MUSTAFA", "JADIEL", "STEFAN", "YOUSEF", "AYDIN", "JERICHO", "ROBIN", "WALLACE", "ALISTAIR", "DAVION", "ALFRED", "ERNESTO", "KYNG", "EVEREST", "GARY", "LEROY", "YAHIR", "BRADEN", "KELVIN", "KRISTIAN", "ADLER", "AVYAAN", "BRAYAN", "JONES", "TRUETT", "ARIES", "JOEY", "RANDY", "JAXX", "JESIAH", "JOVANNI", "AZRIEL", "BRECKEN", "HARLEY", "ZECHARIAH", "GORDON", "JAKAI", "CARL", "GRAYSEN", "KYLEN", "AYAN", "BRANSON", "CROSBY", "DOMINIK", "JABARI", "JAXTYN", "KRISTOPHER", "ULISES", "ZYON", "FOX", "HOWARD", "SALVATORE", "TURNER", "VANCE", "HARLEM", "JAIR", "JAKOBE", "JEREMIAS", "OSIRIS", "AZAEL", "BOWIE", "CANAAN", "ELON", "GRANGER", "KARSYN", "ZAVIER", "CAIN", "DANGELO", "HEATH", "YISROEL", "GIAN", "SHEPARD", "HAROLD", "KAMDYN", "RENE", "RODNEY", "YAAKOV", "ADRIEN", "KARTIER", "CASSIAN", "COLESON", "AHMIR", "DARIAN", "GENESIS", "KALEL", "AGUSTIN", "WYLDER", "YADIEL", "EPHRAIM", "KODY", "NEO", "IGNACIO", "OSMAN", "ALDO", "ABDULLAH", "CORY", "BLAINE", "DIMITRI", "KHAI", "LANDRY", "PALMER", "BENEDICT", "LEIF", "KOEN", "MAXTON", "MORDECHAI", "ZEV", "ATHARV", "BISHOP", "BLAISE", "DAVIAN", "OLIVIA", "EMMA", "CHARLOTTE", "AMELIA", "AVA", "SOPHIA", "ISABELLA", "MIA", "EVELYN", "HARPER", "LUNA", "CAMILA", "GIANNA", "ELIZABETH", "ELEANOR", "ELLA", "ABIGAIL", "SOFIA", "AVERY", "SCARLETT", "EMILY", "ARIA", "PENELOPE", "CHLOE", "LAYLA", "MILA", "NORA", "HAZEL", "MADISON", "ELLIE", "LILY", "NOVA", "ISLA", "GRACE", "VIOLET", "AURORA", "RILEY", "ZOEY", "WILLOW", "EMILIA", "STELLA", "ZOE", "VICTORIA", "HANNAH", "ADDISON", "LEAH", "LUCY", "ELIANA", "IVY", "EVERLY", "LILLIAN", "PAISLEY", "ELENA", "NAOMI", "MAYA", "NATALIE", "KINSLEY", "DELILAH", "CLAIRE", "AUDREY", "AALIYAH", "RUBY", "BROOKLYN", "ALICE", "AUBREY", "AUTUMN", "LEILANI", "SAVANNAH", "VALENTINA", "KENNEDY", "MADELYN", "JOSEPHINE", "BELLA", "SKYLAR", "GENESIS", "SOPHIE", "HAILEY", "SADIE", "NATALIA", "QUINN", "CAROLINE", "ALLISON", "GABRIELLA", "ANNA", "SERENITY", "NEVAEH", "CORA", "ARIANA", "EMERY", "LYDIA", "JADE", "SARAH", "EVA", "ADELINE", "MADELINE", "PIPER", "RYLEE", "ATHENA", "PEYTON", "EVERLEIGH", "VIVIAN", "CLARA", "RAELYNN", "LILIANA", "SAMANTHA", "MARIA", "IRIS", "AYLA", "ELOISE", "LYLA", "ELIZA", "HADLEY", "MELODY", "JULIA", "PARKER", "ROSE", "ISABELLE", "BRIELLE", "ADALYNN", "ARYA", "EDEN", "REMI", "MACKENZIE", "MAEVE", "MARGARET", "REAGAN", "CHARLIE", "ALAIA", "MELANIE", "JOSIE", "ELLIANA", "CECILIA", "MARY", "DAISY", "ALINA", "LUCIA", "XIMENA", "JUNIPER", "KAYLEE", "MAGNOLIA", "SUMMER", "ADALYN", "SLOANE", "AMARA", "ARIANNA", "ISABEL", "REESE", "EMERSYN", "SIENNA", "KEHLANI", "RIVER", "FREYA", "VALERIE", "BLAKELY", "GENEVIEVE", "ESTHER", "VALERIA", "KATHERINE", "KYLIE", "NORAH", "AMAYA", "BAILEY", "EMBER", "RYLEIGH", "GEORGIA", "CATALINA", "EMERSON", "ALEXANDRA", "FAITH", "JASMINE", "ARIELLA", "ASHLEY", "ANDREA", "MILLIE", "JUNE", "KHLOE", "CALLIE", "JULIETTE", "SAGE", "ADA", "ANASTASIA", "OLIVE", "ALANI", "BRIANNA", "ROSALIE", "MOLLY", "BRYNLEE", "AMY", "RUTH", "AUBREE", "GEMMA", "TAYLOR", "OAKLEY", "MARGOT", "ARABELLA", "SARA", "JOURNEE", "HARMONY", "BLAKE", "ALAINA", "ASPEN", "NOELLE", "SELENA", "OAKLYNN", "MORGAN", "LONDYN", "ZURI", "ALIYAH", "JORDYN", "JULIANA", "FINLEY", "PRESLEY", "ZARA", "LEILA", "MARLEY", "SAWYER", "AMIRA", "LILLY", "LONDON", "KIMBERLY", "ELSIE", "ARIEL", "LILA", "ALANA", "DIANA", "KAMILA", "NYLA", "VERA", "HOPE", "ANNIE", "KAIA", "MYLA", "ALYSSA", "ANGELA", "ANA", "LENNON", "EVANGELINE", "HARLOW", "RACHEL", "GRACIE", "ROWAN", "LAILA", "ELISE", "SUTTON", "LILAH", "ADELYN", "PHOEBE", "OCTAVIA", "SYDNEY", "MARIANA", "WREN", "LAINEY", "VANESSA", "TEAGAN", "KAYLA", "MALIA", "ELAINA", "SAYLOR", "BROOKE", "LOLA", "MIRIAM", "ALAYNA", "ADELAIDE", "DANIELA", "JANE", "PAYTON", "JOURNEY", "LILITH", "DELANEY", "DAKOTA", "MYA", "CHARLEE", "ALIVIA", "ANNABELLE", "KAILANI", "LUCILLE", "TRINITY", "GIA", "TATUM", "RAEGAN", "CAMILLE", "KAYLANI", "KALI", "STEVIE", "MAGGIE", "HAVEN", "TESSA", "DAPHNE", "ADALINE", "HAYDEN", "JOANNA", "JOCELYN", "LENA", "EVIE", "JULIET", "FIONA", "CATALEYA", "ANGELINA", "LEIA", "PAIGE", "JULIANNA", "MILANI", "TALIA", "REBECCA", "KENDALL", "HARLEY", "LIA", "PHOENIX", "DAHLIA", "LOGAN", "CAMILLA", "THEA", "JAYLA", "BROOKLYNN", "BLAIR", "VIVIENNE", "HALLIE", "MADILYN", "MCKENNA", "EVELYNN", "OPHELIA", "CELESTE", "ALAYAH", "WINTER", "CATHERINE", "COLLINS", "NINA", "BRIELLA", "PALMER", "NOA", "MCKENZIE", "KIARA", "AMARI", "ADRIANA", "GRACELYNN", "LAUREN", "CALI", "KALANI", "ANIYAH", "NICOLE", "ALEXIS", "MARIAH", "GABRIELA", "WYNTER", "AMINA", "ARIYAH", "ADELYNN", "REMINGTON", "REIGN", "ALAYA", "DREAM", "ALEXANDRIA", "WILLA", "AVIANNA", "MAKAYLA", "GRACELYN", "ELLE", "AMIYAH", "ARIELLE", "ELIANNA", "GISELLE", "BRYNN", "AINSLEY", "AITANA", "CHARLI", "DEMI", "MAKENNA", "ROSEMARY", "DANNA", "IZABELLA", "LILLIANA", "MELISSA", "SAMARA", "LANA", "MABEL", "EVERLEE", "FATIMA", "LEIGHTON", "ESME", "RAELYN", "MADELEINE", "NAYELI", "CAMRYN", "KIRA", "ANNALISE", "SELAH", "SERENA", "ROYALTY", "RYLIE", "CELINE", "LAURA", "BRINLEY", "FRANCES", "MICHELLE", "HEIDI", "RORY", "SABRINA", "DESTINY", "GWENDOLYN", "ALESSANDRA", "POPPY", "AMORA", "NYLAH", "LUCIANA", "MAISIE", "MIRACLE", "JOY", "LIANA", "RAVEN", "SHILOH", "ALLIE", "DALEYZA", "KATE", "LYRIC", "ALICIA", "LEXI", "ADDILYN", "ANAYA", "MALANI", "PAISLEE", "ELISA", "KAYLEIGH", "AZALEA", "FRANCESCA", "JORDAN", "REGINA", "VIVIANA", "AYLIN", "SKYE", "DANIELLA", "MAKENZIE", "VERONICA", "LEGACY", "MAIA", "ARIAH", "ALESSIA", "CARMEN", "ASTRID", "MAREN", "HELEN", "FELICITY", "ALEXA", "DANIELLE", "LORELEI", "PARIS", "ADELINA", "BIANCA", "GABRIELLE", "JAZLYN", "SCARLET", "BRISTOL", "NAVY", "ESMERALDA", "COLETTE", "STEPHANIE", "JOLENE", "MARLEE", "SARAI", "HATTIE", "NADIA", "ROSIE", "KAMRYN", "KENZIE", "ALORA", "HOLLY", "MATILDA", "SYLVIA", "CAMERON", "ARMANI", "EMELIA", "KEIRA", "BRAELYNN", "JACQUELINE", "ALISON", "AMANDA", "CASSIDY", "EMORY", "ARI", "HAISLEY", "JIMENA", "JESSICA", "ELAINE", "DOROTHY", "MIRA", "EVE", "OAKLEE", "AVERIE", "CHARLEIGH", "LYRA", "MADELYNN", "ANGEL", "EDITH", "JENNIFER", "RAYA", "RYAN", "HEAVEN", "KYLA", "WRENLEY", "MEADOW", "CARTER", "KORA", "SAIGE", "KINLEY", "MACI", "MAE", "SALEM", "AISHA", "ADLEY", "CAROLINA", "SIERRA", "ALMA", "HELENA", "BONNIE", "MYLAH", "BRIAR", "AURELIA", "LEONA", "MACIE", "MADDISON", "APRIL", "AVIANA", "LORELAI", "ALONDRA", "KENNEDI", "MONROE", "EMELY", "MALIYAH", "AILANI", "MADILYNN", "RENATA", "KATIE", "ZARIAH", "IMANI", "AMBER", "ANALIA", "ARIYA", "ANYA", "EMBERLY", "EMMY", "MARA", "MARYAM", "DIOR", "MCKINLEY", "VIRGINIA", "AMALIA", "MALLORY", "OPAL", "SHELBY", "CLEMENTINE", "REMY", "XIOMARA", "ELLIOTT", "ELORA", "KATALINA", "ANTONELLA", "SKYLER", "HANNA", "KALIYAH", "ALANNA", "HALEY", "ITZEL", "CECELIA", "JAYLEEN", "KENSLEY", "BEATRICE", "JOURNI", "DYLAN", "IVORY", "YARETZI", "MEREDITH", "SASHA", "GLORIA", "OAKLYN", "SLOAN", "ABBY", "DAVINA", "LYLAH", "ERIN", "REYNA", "KAITLYN", "MICHAELA", "NIA", "FERNANDA", "JALIYAH", "JENNA", "SYLVIE", "MIRANDA", "ANNE", "MINA", "MYRA", "ALEENA", "ALIA", "FRANKIE", "ELLIS", "KATHRYN", "NALANI", "NOLA", "JEMMA", "LENNOX", "MARIE", "ANGELICA", "CASSANDRA", "CALLIOPE", "ADRIANNA", "IVANNA", "ZELDA", "FAYE", "KARSYN", "OAKLEIGH", "DAYANA", "AMIRAH", "MEGAN", "SIENA", "REINA", "RHEA", "JULIETA", "MALAYSIA", "HENLEY", "LIBERTY", "LESLIE", "ALEJANDRA", "KELSEY", "CHARLEY", "CAPRI", "PRISCILLA", "ZARIYAH", "SAVANNA", "EMERIE", "CHRISTINA", "SKYLA", "MACY", "MARIAM", "MELINA", "CHELSEA", "DALLAS", "LAUREL", "BRIANA", "HOLLAND", "LILIAN", "AMAIA", "BLAIRE", "MARGO", "LOUISE", "ROSALIA", "ALEAH", "BETHANY", "FLORA", "KYLEE", "KENDRA", "SUNNY", "LANEY", "TIANA", "CHAYA", "ELLIANNA", "MILAN", "ALIANA", "ESTELLA", "JULIE", "YARA", "ROSA", "CHEYENNE", "EMMIE", "CARLY", "JANELLE", "KYRA", "NAYA", "MALAYA", "SEVYN", "LINA", "MIKAYLA", "JAYDA", "LEYLA", "EILEEN", "IRENE", "KARINA", "AILEEN", "ALIZA", "KATALEYA", "KORI", "INDIE", "LARA", "ROMINA", "JADA", "KIMBER", "AMANI", "LIV", "TREASURE", "LOUISA", "MARLEIGH", "WINNIE", "KASSIDY", "NOAH", "MONICA", "KEILANI", "ZAHRA", "ZAYLEE", "HADASSAH", "JAMIE", "ALLYSON", "ANAHI", "MAXINE", "KARLA", "KHALEESI", "JOHANNA", "PENNY", "HAYLEY", "MARILYN", "DELLA", "FREYJA", "JAZMIN", "KENNA", "ASHLYN", "FLORENCE", "EZRA", "MELANY", "MURPHY", "SKY", "MARINA", "NOEMI", "CORALINE", "SELENE", "BRIDGET", "ALAIYA", "ANGIE", "FALLON", "THALIA", "RAYNA", "MARTHA", "HALLE", "ESTRELLA", "JOELLE", "KINSLEE", "ROSELYN", "THEODORA", "JOLIE", "DANI", "ELODIE", "HALO", "NALA", "PROMISE", "JUSTICE", "NELLIE", "NOVAH", "ESTELLE", "JENESIS", "MILEY", "HADLEE", "JANIYAH", "WAVERLY", "BRAELYN", "PEARL", "AILA", "KATELYN", "SARIYAH", "AZARIAH", "BEXLEY", "GIANA", "LEA", "CADENCE", "MAVIS", "ILA", "RIVKA", "JOVIE", "YARELI", "BELLAMY", "KAMIYAH", "KARA", "BAYLEE", "JIANNA", "KAI", "ALENA", "NOVALEE", "ELLIOT", "LIVIA", "ASHLYNN", "DENVER", "EMMALYN", "PERSEPHONE", "MARCELINE", "JAZMINE", "KIANA", "MIKAELA", "ALIYA", "GALILEA", "HARLEE", "JAYLAH", "LILLIE", "MERCY", "ENSLEY", "BRIA", "KALLIE", "CELIA", "BERKLEY", "RAMONA", "JAYLANI", "JESSIE", "AUBRIE", "MADISYN", "PAULINA", "AVERI", "AYA", "CHANA", "MILANA", "CLEO", "IYLA", "CYNTHIA", "HANA", "LACEY", "ANDI", "GIULIANA", "MILENA", "LEILANY", "SAOIRSE", "ADELE", "DREW", "BAILEE", "HUNTER", "RAYNE", "ANAIS", "KAMARI", "PAULA", "ROSALEE", "TERESA", "ZORA", "AVAH", "BELEN", "GRETA", "LAYNE", "SCOUT", "ZANIYAH", "AMELIE", "DULCE", "CHANEL", "CLARE", "REBEKAH", "GIOVANNA", "ELLISON", "ISABELA", "KAYDENCE", "ROSALYN", "ROYAL", "ALIANNA", "AUGUST", "NYRA", "VIENNA", "AMOURA", "ANIKA", "HARMONI", "KELLY", "LINDA", "AUBRIELLA", "KAIRI", "RYANN", "AVAYAH", "GWEN", "WHITLEY", "NOOR", "KHALANI", "MARIANNA", "ADDYSON", "ANNIKA", "KARTER", "VADA", "TIFFANY", "ARTEMIS", "CLOVER", "LAYLAH", "PAISLEIGH", "ELYSE", "KAISLEY", "VEDA", "ZENDAYA", "SIMONE", "ALEXIA", "ALISSON", "ANGELIQUE", "OCEAN", "ELIA", "LILIANNA", "MALEAH", "AVALYNN", "MARISOL", "GOLDIE", "MALAYAH", "EMMELINE", "PALOMA", "RAINA", "BRYNLEIGH", "CHANDLER", "VALERY", "ADALEE", "TINSLEY", "VIOLETA", "BAYLOR", "LAURYN", "MARLOWE", "BIRDIE", "JAYCEE", "LEXIE", "LORETTA", "LILYANA", "PRINCESS", "SHAY", "HADLEIGH", "NATASHA", "INDIGO", "ZARIA", "ADDISYN", "DEBORAH", "LEANNA", "BARBARA", "KIMORA", "EMERALD", "RAQUEL", "JULISSA", "ROBIN", "AUSTYN", "DALIA", "NYOMI", "ELLEN", "KYNLEE", "SALMA", "LUELLA", "ZAYLA", "ADDILYNN", "GIAVANNA", "SAMIRA", "AMARIS", "MADALYN", "SCARLETTE", "STORMI", "ETTA", "AYLEEN", "BRITTANY", "BRYLEE", "ARACELI", "EGYPT", "ILIANA", "PAITYN", "ZAINAB", "BILLIE", "HAYLEE", "INDIA", "KAIYA", "NANCY", "CLARISSA", "MAZIKEEN", "TAYTUM", "AUBRIELLE", "RYLAN", "AINHOA", "ASPYN", "ELINA", "ELSA", "MAGDALENA", "KAILEY", "ARLETH", "JOYCE", "JUDITH", "CRYSTAL", "EMBERLYNN", "LANDRY", "PAOLA", "BRAYLEE", "GUINEVERE", "AARNA", "AIYANA", "KAHLANI", "LYANNA", "SARIAH", "ITZAYANA", "ANIYA", "FRIDA", "JAYLENE", "KIERA", "LOYALTY", "AZARIA", "JAYLEE", "KAMILAH", "KEYLA", "KYLEIGH", "MICAH", "NATALY", "KATHLEEN", "ZOYA", "MEGHAN", "SORAYA", "ZOIE", "ARLETTE", "ZOLA", "LUISA", "VIDA", "RYDER", "TATIANA", "TORI", "AARYA", "ELEANORA", "SANDRA", "SOLEIL", "ANNABELLA" };
    string[] lnames = { "SMITH", "JOHNSON", "WILLIAMS", "BROWN", "JONES", "GARCIA", "MILLER", "DAVIS", "RODRIGUEZ", "MARTINEZ", "HERNANDEZ", "LOPEZ", "GONZALEZ", "WILSON", "ANDERSON", "THOMAS", "TAYLOR", "MOORE", "JACKSON", "MARTIN", "LEE", "PEREZ", "THOMPSON", "WHITE", "HARRIS", "SANCHEZ", "CLARK", "RAMIREZ", "LEWIS", "ROBINSON", "WALKER", "YOUNG", "ALLEN", "KING", "WRIGHT", "SCOTT", "TORRES", "NGUYEN", "HILL", "FLORES", "GREEN", "ADAMS", "NELSON", "BAKER", "HALL", "RIVERA", "CAMPBELL", "MITCHELL", "CARTER", "ROBERTS", "GOMEZ", "PHILLIPS", "EVANS", "TURNER", "DIAZ", "PARKER", "CRUZ", "EDWARDS", "COLLINS", "REYES", "STEWART", "MORRIS", "MORALES", "MURPHY", "COOK", "ROGERS", "GUTIERREZ", "ORTIZ", "MORGAN", "COOPER", "PETERSON", "BAILEY", "REED", "KELLY", "HOWARD", "RAMOS", "KIM", "COX", "WARD", "RICHARDSON", "WATSON", "BROOKS", "CHAVEZ", "WOOD", "JAMES", "BENNETT", "GRAY", "MENDOZA", "RUIZ", "HUGHES", "PRICE", "ALVAREZ", "CASTILLO", "SANDERS", "PATEL", "MYERS", "LONG", "ROSS", "FOSTER", "JIMENEZ", "POWELL", "JENKINS", "PERRY", "RUSSELL", "SULLIVAN", "BELL", "COLEMAN", "BUTLER", "HENDERSON", "BARNES", "GONZALES", "FISHER", "VASQUEZ", "SIMMONS", "ROMERO", "JORDAN", "PATTERSON", "ALEXANDER", "HAMILTON", "GRAHAM", "REYNOLDS", "GRIFFIN", "WALLACE", "MORENO", "WEST", "COLE", "HAYES", "BRYANT", "HERRERA", "GIBSON", "ELLIS", "TRAN", "MEDINA", "AGUILAR", "STEVENS", "MURRAY", "FORD", "CASTRO", "MARSHALL", "OWENS", "HARRISON", "FERNANDEZ", "MCDONALD", "WOODS", "WASHINGTON", "KENNEDY", "WELLS", "VARGAS", "HENRY", "CHEN", "FREEMAN", "WEBB", "TUCKER", "GUZMAN", "BURNS", "CRAWFORD", "OLSON", "SIMPSON", "PORTER", "HUNTER", "GORDON", "MENDEZ", "SILVA", "SHAW", "SNYDER", "MASON", "DIXON", "MUNOZ", "HUNT", "HICKS", "HOLMES", "PALMER", "WAGNER", "BLACK", "ROBERTSON", "BOYD", "ROSE", "STONE", "SALAZAR", "FOX", "WARREN", "MILLS", "MEYER", "RICE", "SCHMIDT", "GARZA", "DANIELS", "FERGUSON", "NICHOLS", "STEPHENS", "SOTO", "WEAVER", "RYAN", "GARDNER", "PAYNE", "GRANT", "DUNN", "KELLEY", "SPENCER", "HAWKINS", "ARNOLD", "PIERCE", "VAZQUEZ", "HANSEN", "PETERS", "SANTOS", "HART", "BRADLEY", "KNIGHT", "ELLIOTT", "CUNNINGHAM", "DUNCAN", "ARMSTRONG", "HUDSON", "CARROLL", "LANE", "RILEY", "ANDREWS", "ALVARADO", "RAY", "DELGADO", "BERRY", "PERKINS", "HOFFMAN", "JOHNSTON", "MATTHEWS", "PENA", "RICHARDS", "CONTRERAS", "WILLIS", "CARPENTER", "LAWRENCE", "SANDOVAL", "GUERRERO", "GEORGE", "CHAPMAN", "RIOS", "ESTRADA", "ORTEGA", "WATKINS", "GREENE", "NUNEZ", "WHEELER", "VALDEZ", "HARPER", "BURKE", "LARSON", "SANTIAGO", "MALDONADO", "MORRISON", "FRANKLIN", "CARLSON", "AUSTIN", "DOMINGUEZ", "CARR", "LAWSON", "JACOBS", "OBRIEN", "LYNCH", "SINGH", "VEGA", "BISHOP", "MONTGOMERY", "OLIVER", "JENSEN", "HARVEY", "WILLIAMSON", "GILBERT", "DEAN", "SIMS", "ESPINOZA", "HOWELL", "LI", "WONG", "REID", "HANSON", "LE", "MCCOY", "GARRETT", "BURTON", "FULLER", "WANG", "WEBER", "WELCH", "ROJAS", "LUCAS", "MARQUEZ", "FIELDS", "PARK", "YANG", "LITTLE", "BANKS", "PADILLA", "DAY", "WALSH", "BOWMAN", "SCHULTZ", "LUNA", "FOWLER", "MEJIA", "DAVIDSON", "ACOSTA", "BREWER", "MAY", "HOLLAND", "JUAREZ", "NEWMAN", "PEARSON", "CURTIS", "CORTEZ", "DOUGLAS", "SCHNEIDER", "JOSEPH", "BARRETT", "NAVARRO", "FIGUEROA", "KELLER", "AVILA", "WADE", "MOLINA", "STANLEY", "HOPKINS", "CAMPOS", "BARNETT", "BATES", "CHAMBERS", "CALDWELL", "BECK", "LAMBERT", "MIRANDA", "BYRD", "CRAIG", "AYALA", "LOWE", "FRAZIER", "POWERS", "NEAL", "LEONARD", "GREGORY", "CARRILLO", "SUTTON", "FLEMING", "RHODES", "SHELTON", "SCHWARTZ", "NORRIS", "JENNINGS", "WATTS", "DURAN", "WALTERS", "COHEN", "MCDANIEL", "MORAN", "PARKS", "STEELE", "VAUGHN", "BECKER", "HOLT", "DELEON", "BARKER", "TERRY", "HALE", "LEON", "HAIL", "BENSON", "HAYNES", "HORTON", "MILES", "LYONS", "PHAM", "GRAVES", "BUSH", "THORNTON", "WOLFE", "WARNER", "CABRERA", "MCKINNEY", "MANN", "ZIMMERMAN", "DAWSON", "LARA", "FLETCHER", "PAGE", "MCCARTHY", "LOVE", "ROBLES", "CERVANTES", "SOLIS", "ERICKSON", "REEVES", "CHANG", "KLEIN", "SALINAS", "FUENTES", "BALDWIN", "DANIEL", "SIMON", "VELASQUEZ", "HARDY", "HIGGINS", "AGUIRRE", "LIN", "CUMMINGS", "CHANDLER", "SHARP", "BARBER", "BOWEN", "OCHOA", "DENNIS", "ROBBINS", "LIU", "RAMSEY", "FRANCIS", "GRIFFITH", "PAUL", "BLAIR", "OCONNOR", "CARDENAS", "PACHECO", "CROSS", "CALDERON", "QUINN", "MOSS", "SWANSON", "CHAN", "RIVAS", "KHAN", "RODGERS", "SERRANO", "FITZGERALD", "ROSALES", "STEVENSON", "CHRISTENSEN", "MANNING", "GILL", "CURRY", "MCLAUGHLIN", "HARMON", "MCGEE", "GROSS", "DOYLE", "GARNER", "NEWTON", "BURGESS", "REESE", "WALTON", "BLAKE", "TRUJILLO", "ADKINS", "BRADY", "GOODMAN", "ROMAN", "WEBSTER", "GOODWIN", "FISCHER", "HUANG", "POTTER", "DELACRUZ", "MONTOYA", "TODD", "WU", "HINES", "MULLINS", "CASTANEDA", "MALONE", "CANNON", "TATE", "MACK", "SHERMAN", "HUBBARD", "HODGES", "ZHANG", "GUERRA", "WOLF", "VALENCIA", "SAUNDERS", "FRANCO", "ROWE", "GALLAGHER", "FARMER", "HAMMOND", "HAMPTON", "TOWNSEND", "INGRAM", "WISE", "GALLEGOS", "CLARKE", "BARTON", "SCHROEDER", "MAXWELL", "WATERS", "LOGAN", "CAMACHO", "STRICKLAND", "NORMAN", "PERSON", "COLON", "PARSONS", "FRANK", "HARRINGTON", "GLOVER", "OSBORNE", "BUCHANAN", "CASEY", "FLOYD", "PATTON", "IBARRA", "BALL", "TYLER", "SUAREZ", "BOWERS", "OROZCO", "SALAS", "COBB", "GIBBS", "ANDRADE", "BAUER", "CONNER", "MOODY", "ESCOBAR", "MCGUIRE", "LLOYD", "MUELLER", "HARTMAN", "FRENCH", "KRAMER", "MCBRIDE", "POPE", "LINDSEY", "VELAZQUEZ", "NORTON", "MCCORMICK", "SPARKS", "FLYNN", "YATES", "HOGAN", "MARSH", "MACIAS", "VILLANUEVA", "ZAMORA", "PRATT", "STOKES", "OWEN", "BALLARD", "LANG", "BROCK", "VILLARREAL", "CHARLES", "DRAKE", "BARRERA", "CAIN", "PATRICK", "PINEDA", "BURNETT", "MERCADO", "SANTANA", "SHEPHERD", "BAUTISTA", "ALI", "SHAFFER", "LAMB", "TREVINO", "MCKENZIE", "HESS", "BEIL", "OLSEN", "COCHRAN", "MORTON", "NASH", "WILKINS", "PETERSEN", "BRIGGS", "SHAH", "ROTH", "NICHOLSON", "HOLLOWAY", "LOZANO", "RANGEL", "FLOWERS", "HOOVER", "SHORT", "ARIAS", "MORA", "VALENZUELA", "BRYAN", "MEYERS", "WEISS", "UNDERWOOD", "BASS", "GREER", "SUMMERS", "HOUSTON", "CARSON", "MORROW", "CLAYTON", "WHITAKER", "DECKER", "YODER", "COLLIER", "ZUNIGA", "CAREY", "WILCOX", "MELENDEZ", "POOLE", "ROBERSON", "LARSEN", "CONLEY", "DAVENPORT", "COPELAND", "MASSEY", "LAM", "HUFF", "ROCHA", "CAMERON", "JEFFERSON", "HOOD", "MONROE", "ANTHONY", "PITTMAN", "HUYNH", "RANDALL", "SINGLETON", "KIRK", "COMBS", "MATHIS", "CHRISTIAN", "SKINNER", "BRADFORD", "RICHARD", "GALVAN", "WALL", "BOONE", "KIRBY", "WILKINSON", "BRIDGES", "BRUCE", "ATKINSON", "VELEZ", "MEZA", "ROY", "VINCENT", "YORK", "HODGE", "VILLA", "ABBOTT", "ALLISON", "TAPIA", "GATES", "CHASE", "SOSA", "SWEENEY", "FARRELL", "WYATT", "DALTON", "HORN", "BARRON", "PHELPS", "YU", "DICKERSON", "HEATH", "FOLEY", "ATKINS", "MATHEWS", "BONILLA", "ACEVEDO", "BENITEZ", "ZAVALA", "HENSLEY", "GLENN", "CISNEROS", "HARRELL", "SHIELDS", "RUBIO", "HUFFMAN", "CHOI", "BOYER", "GARRISON", "ARROYO", "BOND", "KANE", "HANCOCK", "CALLAHAN", "DILLON", "CLINE", "WIGGINS", "GRIMES", "ARELLANO", "MELTON", "ONEILL", "SAVAGE", "HO", "BELTRAN", "PITTS", "PARRISH", "PONCE", "RICH", "BOOTH", "KOCH", "GOLDEN", "WARE", "BRENNAN", "MCDOWELL", "MARKS", "CANTU", "HUMPHREY", "BAXTER", "SAWYER", "CLAY", "TANNER", "HUTCHINSON", "KAUR", "BERG", "WILEY", "GILMORE", "RUSSO", "VILLEGAS", "HOBBS", "KEITH", "WILKERSON", "AHMED", "BEARD", "MCCLAIN", "MONTES", "MATA", "ROSARIO", "VANG", "WALTER", "HENSON", "ONEAL", "MOSLEY", "MCCLURE", "BEASLEY", "STEPHENSON", "SNOW", "HUERTA", "PRESTON", "VANCE", "BARRY", "JOHNS", "EATON", "BLACKWELL", "DYER", "PRINCE", "MACDONALD", "SOLOMON", "GUEVARA", "STAFFORD", "ENGLISH", "HURST", "WOODARD", "CORTES", "SHANNON", "KEMP", "NOLAN", "MCCULLOUGH", "MERRITT", "MURILLO", "MOON", "SALGADO", "STRONG", "KLINE", "CORDOVA", "BARAJAS", "ROACH", "ROSAS", "WINTERS", "JACOBSON", "LESTER", "KNOX", "BULLOCK", "KERR", "LEACH", "MEADOWS", "ORR", "DAVILA", "WHITEHEAD", "PRUITT", "KENT", "CONWAY", "MCKEE", "BARR", "DAVID", "DEJESUS", "MARIN", "BERGER", "MCINTYRE", "BLANKENSHIP", "GAINES", "PALACIOS", "CUEVAS", "BARTLETT", "DURHAM", "DORSEY", "MCCALL", "ODONNELL", "STEIN", "BROWNING", "STOUT", "LOWERY", "SLOAN", "MCLEAN", "HENDRICKS", "CALHOUN", "SEXTON", "CHUNG", "GENTRY", "HULL", "DUARTE", "ELLISON", "NIELSEN", "GILLESPIE", "BUCK", "MIDDLETON", "SELLERS", "LEBLANC", "ESPARZA", "HARDIN", "BRADSHAW", "MCINTOSH", "HOWE", "LIVINGSTON", "FROST", "GLASS", "MORSE", "KNAPP", "HERMAN", "STARK", "BRAVO", "NOBLE", "SPEARS", "WEEKS", "CORONA", "FREDERICK", "BUCKLEY", "MCFARLAND", "HEBERT", "ENRIQUEZ", "HICKMAN", "QUINTERO", "RANDOLPH", "SCHAEFER", "WALLS", "TREJO", "HOUSE", "REILLY", "PENNINGTON", "MICHAEL", "CONRAD", "GILES", "BENJAMIN", "CROSBY", "FITZPATRICK", "DONOVAN", "MAYS", "MAHONEY", "VALENTINE", "RAYMOND", "MEDRANO", "HAHN", "MCMILLAN", "SMALL", "BENTLEY", "FELIX", "PECK", "LUCERO", "BOYLE", "HANNA", "PACE", "RUSH", "HURLEY", "HARDING", "MCCONNELL", "BERNAL", "NAVA", "AYERS", "EVERETT", "VENTURA", "AVERY", "PUGH", "MAYER", "BENDER", "SHEPARD", "MCMAHON", "LANDRY", "CASE", "SAMPSON", "MOSES", "MAGANA", "BLACKBURN", "DUNLAP", "GOULD", "DUFFY", "VAUGHAN", "HERRING", "MCKAY", "ESPINOSA", "RIVERS", "FARLEY", "BERNARD", "ASHLEY", "FRIEDMAN", "POTTS", "TRUONG", "COSTA", "CORREA", "BLEVINS", "NIXON", "CLEMENTS", "FRY", "DELAROSA", "BEST", "BENTON", "LUGO", "PORTILLO", "DOUGHERTY", "CRANE", "HALEY", "PHAN", "VILLALOBOS", "BLANCHARD", "HORNE", "FINLEY", "QUINTANA", "LYNN", "ESQUIVEL", "BEAN", "DODSON", "MULLEN", "XIONG", "HAYDEN", "CANO", "LEVY", "HUBER", "RICHMOND", "MOYER", "LIM", "FRYE", "SHEPPARD", "MCCARTY", "AVALOS", "BOOKER", "WALLER", "PARRA", "WOODWARD", "JARAMILLO", "KRUEGER", "RASMUSSEN", "BRANDT", "PERALTA", "DONALDSON", "STUART", "FAULKNER", "MAYNARD", "GALINDO", "COFFEY", "ESTES", "SANFORD", "BURCH", "MADDOX", "VO", "OCONNELL", "VU", "ANDERSEN", "SPENCE", "MCPHERSON", "CHURCH", "SCHMITT", "STANTON", "LEAL", "CHERRY", "COMPTON", "DUDLEY", "SIERRA", "POLLARD", "ALFARO", "HESTER", "PROCTOR", "LU", "HINTON", "NOVAK", "GOOD", "MADDEN", "MCCANN", "TERRELL", "JARVIS", "DICKSON", "REYNA", "CANTRELL", "MAYO", "BRANCH", "HENDRIX", "ROLLINS", "ROWLAND", "WHITNEY", "DUKE", "ODOM", "DAUGHERTY", "TRAVIS", "TANG", "ARCHER" };
    // Start is called before the first frame update
    void Start()
    {
        string pilot = "PILOT: ";
        int randomIndex = Random.Range(0, fnames.Length);
        pilot += fnames[randomIndex] + " ";
        randomIndex = Random.Range(0, lnames.Length);
        pilot += lnames[randomIndex];
        pilotText.SetText(pilot);

    }

    // Update is called once per frame
    void Update()
    {
        if(fadeIn.alpha > 0)
        {
            fadeIn.alpha -= Time.deltaTime;
        }
    }

    void AssignName()
    {

    }
}