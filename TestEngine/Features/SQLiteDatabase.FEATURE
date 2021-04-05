@Back-End @Demo
Feature: Database Test Demo
    AS A USER WITH ACCESS TO THE BACK-END
    I SHOULD BE ABLE TO WRITE TO THE DATABASE
    AND THEN READ FROM THE DATABASE

    Background:
        Given   THE SQLITE DATABASE DOES NOT EXIST

    Scenario Template: [01/01] Write And Read Data To A Database
        Given   I BOOTSTRAP AND CONNECT TO THE DATABASE
        And     I CONFIRM THAT THE CONNECTION IS ALIVE
        When    I CREATE A "ENTRIES" TABLE
        And     I INSERT "<language>" AND "<entry>" INTO THE "ENTRIES" TABLE
        Then    I CONFIRM THAT A ROW HAS BEEN CREATED IN THE "ENTRIES" TABLE

        Examples:

            | language		| entry					|
            | Afrikaans     | Hello Wêreld!			|
            | Albanian      | Përshendetje Botë!	|
            | Amharic       | ሰላም ልዑል!				|
            | Arabic        | مرحبا بالعالم!				|
            | Armenian      | Բարեւ աշխարհ!			|
            | Basque        | Kaixo Mundua!			|
            | Belarussian   | Прывітанне Сусвет!	|
            | Bengali       | ওহে বিশ্ব!					|
            | Bulgarian     | Здравей свят!			|
            | Catalan       | Hola Món!				|
            | Chichewa      | Moni Dziko Lapansi!	|
			| Chinese       | 你好世界！				|
            | Croatian      | Pozdrav Svijete!		|
            | Czech         | Ahoj Světe!			|
            | Danish        | Hej Verden!			|
            | Dutch         | Hallo Wereld!			|
            | English       | Hello World!			|
            | Estonian      | Tere Maailm!			|
            | Finnish       | Hei Maailma!			|
            | French        | Bonjour Monde!		|
            | Frisian       | Hallo Wrâld!			|
            | Georgian      | გამარჯობა მსოფლიო!		|
            | German        | Hallo Welt!			|
            | Greek         | Γειά Σου Κόσμε!		|
            | Hausa         | Sannu Duniya!			|
            | Hebrew        | שלום עולם!				|
            | Hindi         | नमस्ते दुनिया!				|
            | Hungarian     | Helló Világ!			|
            | Icelandic     | Halló Heimur!			|
            | Igbo          | Ndewo Ụwa!			|
            | Indonesian    | Halo Dunia!			|
            | Italian       | Ciao Mondo!			|
            | Japanese      | こんにちは世界！			|
            | Kazakh        | Сәлем Әлем!			|
            | Khmer         | សួស្តី​ពិភពលោក!				|
            | Kyrgyz        | Салам дүйнө!			|
            | Lao           | ສະ​ບາຍ​ດີ​ຊາວ​ໂລກ!			|
            | Latvian       | Sveika Pasaule!		|
            | Lithuanian    | Labas Pasauli!		|
            | Luxemburgish  | Moien Welt!			|
            | Macedonian    | Здраво Свету!			|
            | Malay         | Hai Dunia!			|
            | Malayalam     | ഹലോ വേൾഡ്!			|
            | Mongolian     | Сайн Yу дэлхий!		|
            | Myanmar       | မင်္ဂလာပါကမ္ဘာလောက!			|
            | Nepali        | नमस्कार संसार!				|
            | Norwegian     | Hei Verden!			|
            | Pashto        | سلام نړی!					|
            | Persian       | سلام دنیا!					|
            | Polish        | Witaj Świecie!		|
            | Portuguese    | Olá Mundo!			|
            | Punjabi       | ਸਤਿ ਸ੍ਰੀ ਅਕਾਲ ਦੁਨਿਆ!			|
            | Romanian      | Salut Lume!			|
            | Russian       | Привет Mир!			|
            | Scots Gaelic  | Hàlo A Shaoghail!		|
            | Serbian       | Здраво Свете!			|
            | Sesotho       | Lefatše Lumela!		|
            | Sinhala       | හෙලෝ වර්ල්ඩ්!				|
            | Slovenian     | Pozdravljen Svet!		|
            | Spanish       | ¡Hola Mundo!			|
            | Sundanese     | Halo Dunya!			|
            | Swahili       | Salamu Dunia!			|
            | Swedish       | Hej Världen!			|
            | Tajik         | Салом Ҷаҳон!			|
            | Thai          | สวัสดีชาวโลก!				|
            | Turkish       | Selam Dünya!			|
            | Ukrainian     | Привіт Світ!			|
            | Uzbek         | Salom Dunyo!			|
            | Vietnamese    | Chào Thế Giới!		|
            | Welsh         | Helo Byd!				|
            | Xhosa         | Molo Lizwe!			|
            | Yiddish       | העלא וועלט!				|
            | Yoruba        | Mo ki O Ile Aiye!		|
            | Zulu          | Sawubona Mhlaba!		|
