using System.Collections.Generic;

namespace Calculator.Helpers
{
    public class AsciiTable
    {
        // ASCII Table
        public static List<string> AsciiCodes = new List<string>
        {
            "NUL (null)",
            "SOH (start of header)",
            "STX (start of text)",
            "ETX (end of text)",
            "EOT (end of transmission)",
            "ENQ (enquiry)",
            "ACK (acknowledge)",
            "BEL (bell)",
            "BS (backspace)",
            "HT (horizontal tab)",
            "LF (line feed - new line)",
            "VT (vertical tab)",
            "FF (form feed - new page)",
            "CR (carriage return)",
            "SO (shift out)",
            "SI (shift in)",
            "DLE (data link escape)",
            "DC1 (device control 1)",
            "DC2 (device control 2)",
            "DC3 (device control 3)",
            "DC4 (device control 4)",
            "NAK (negative acknowledge)",
            "SYN (synchronous idle)",
            "ETB (end of transmission block)",
            "CAN (cancel)",
            "EM (end of medium)",
            "SUB (substitute)",
            "ESC (escape)",
            "FS (file separator)",
            "GS (group separator)",
            "RS (record separator)",
            "US (unit separator)",
            "(space)",
            "!",
            "\"",
            "#",
            "$",
            "%",
            "&",
            "'",
            "(",
            ")",
            "*",
            "+",
            ",",
            "-",
            ".",
            "/",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            ":",
            ";",
            "<",
            "=",
            ">",
            "?",
            "@",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "[",
            "\\",
            "]",
            "^",
            "_",
            "`",
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z",
            "{",
            "|",
            "}",
            "~",
            "DEL (delete)",
            "€",
            "",
            "‚",
            "ƒ",
            "„",
            "…",
            "†",
            "‡",
            "ˆ",
            "‰",
            "Š",
            "‹",
            "Œ",
            "",
            "Ž",
            "",
            "",
            "‘",
            "’",
            "“",
            "”",
            "•",
            "–",
            "—",
            "˜",
            "™",
            "š",
            "›",
            "œ",
            "",
            "ž",
            "Ÿ",
            "",
            "¡",
            "¢",
            "£",
            "¤",
            "¥",
            "¦",
            "§",
            "¨",
            "©",
            "ª",
            "«",
            "¬",
            "­",
            "®",
            "¯",
            "°",
            "±",
            "²",
            "³",
            "´",
            "µ",
            "¶",
            "·",
            "¸",
            "¹",
            "º",
            "»",
            "¼",
            "½",
            "¾",
            "¿",
            "À",
            "Á",
            "Â",
            "Ã",
            "Ä",
            "Å",
            "Æ",
            "Ç",
            "È",
            "É",
            "Ê",
            "Ë",
            "Ì",
            "Í",
            "Î",
            "Ï",
            "Ð",
            "Ñ",
            "Ò",
            "Ó",
            "Ô",
            "Õ",
            "Ö",
            "×",
            "Ø",
            "Ù",
            "Ú",
            "Û",
            "Ü",
            "Ý",
            "Þ",
            "ß",
            "à",
            "á",
            "â",
            "ã",
            "ä",
            "å",
            "æ",
            "ç",
            "è",
            "é",
            "ê",
            "ë",
            "ì",
            "í",
            "î",
            "ï",
            "ð",
            "ñ",
            "ò",
            "ó",
            "ô",
            "õ",
            "ö",
            "÷",
            "ø",
            "ù",
            "ú",
            "û",
            "ü",
            "ý",
            "þ",
            "ÿ"
        };

        // ASCII Table stripped
        public static List<string> AsciiCodesStripped = new List<string>
        {
            "[NUL]",
            "[SOH]",
            "[STX]",
            "[ETX]",
            "[EOT]",
            "[ENQ]",
            "[ACK]",
            "[BEL]",
            "[BS]",
            "[HT]",
            "[LF]",
            "[VT]",
            "[FF]",
            "[CR]",
            "[SO]",
            "[SI]",
            "[DLE]",
            "[DC1]",
            "[DC2]",
            "[DC3]",
            "[DC4]",
            "[NAK]",
            "[SYN]",
            "[ETB]",
            "[CAN]",
            "[EM]",
            "[SUB]",
            "[ESC]",
            "[FS]",
            "[GS]",
            "[RS]",
            "[US]",
            "[SPACE]",
            "!",
            "\"",
            "#",
            "$",
            "%",
            "&",
            "'",
            "(",
            ")",
            "*",
            "+",
            ",",
            "-",
            ".",
            "/",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            ":",
            ";",
            "<",
            "=",
            ">",
            "?",
            "@",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "[",
            "\\",
            "]",
            "^",
            "_",
            "`",
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z",
            "{",
            "|",
            "}",
            "~",
            "[DEL]",
            "€",
            "",
            "‚",
            "ƒ",
            "„",
            "…",
            "†",
            "‡",
            "ˆ",
            "‰",
            "Š",
            "‹",
            "Œ",
            "",
            "Ž",
            "",
            "",
            "‘",
            "’",
            "“",
            "”",
            "•",
            "–",
            "—",
            "˜",
            "™",
            "š",
            "›",
            "œ",
            "",
            "ž",
            "Ÿ",
            "",
            "¡",
            "¢",
            "£",
            "¤",
            "¥",
            "¦",
            "§",
            "¨",
            "©",
            "ª",
            "«",
            "¬",
            "­",
            "®",
            "¯",
            "°",
            "±",
            "²",
            "³",
            "´",
            "µ",
            "¶",
            "·",
            "¸",
            "¹",
            "º",
            "»",
            "¼",
            "½",
            "¾",
            "¿",
            "À",
            "Á",
            "Â",
            "Ã",
            "Ä",
            "Å",
            "Æ",
            "Ç",
            "È",
            "É",
            "Ê",
            "Ë",
            "Ì",
            "Í",
            "Î",
            "Ï",
            "Ð",
            "Ñ",
            "Ò",
            "Ó",
            "Ô",
            "Õ",
            "Ö",
            "×",
            "Ø",
            "Ù",
            "Ú",
            "Û",
            "Ü",
            "Ý",
            "Þ",
            "ß",
            "à",
            "á",
            "â",
            "ã",
            "ä",
            "å",
            "æ",
            "ç",
            "è",
            "é",
            "ê",
            "ë",
            "ì",
            "í",
            "î",
            "ï",
            "ð",
            "ñ",
            "ò",
            "ó",
            "ô",
            "õ",
            "ö",
            "÷",
            "ø",
            "ù",
            "ú",
            "û",
            "ü",
            "ý",
            "þ",
            "ÿ"
        };
    }
}