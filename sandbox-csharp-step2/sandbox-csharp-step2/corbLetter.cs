using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step2 {
    class corbLetter {

        // Alphabet
        public String[] alphabet = { " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "&", "?"};

        Random random = new Random();

        // String qui stock la dernière ligne
        public string lastRandomLineOfRandomLetters { get; set; }

        // Récupération d'une lettre de la randomLine
        public String getIndexLetterFromRandomLine(int index) {
            return lastRandomLineOfRandomLetters.Substring(Math.Max(index, index));
        }

        public String getRandomLetterFromAlphabet() {
            int position = random.Next(0, alphabet.Length);
            return alphabet[position];
        }

        /* Récupération d'une randomLetter;
         * @Input : l'indice de la lettre dans la ligne générée
         */
        public String getRandomLetterFromAlphabet(int index) {
            int position = random.Next(0 , alphabet.Length);
            return alphabet[position];
        }

        // Génération d'une ligne de randomLetter
        public String generateRandomLineOfRandomLetters() {
            System.Threading.Thread.Sleep(35);
            String result = "";

            for (int i = 0; i < 100; i++) {
                result += getRandomLetterFromAlphabet();
            }

            return result;
        }

    }
}
