using System;
using Xunit;

namespace dark_place_game.tests
{
    
    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 2748;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 978;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";

        [Fact]
        public void VraiShouldBeTrue()
        {
            var vrai = true;
            Assert.True(vrai);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null,EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        // #TODO_ETAPE_4
        [Fact]
        public void BrouzoufIsAValidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            var ch = new CurrencyHolder("Brouzouf", EXEMPLE_CAPACITE_VALIDE, 0);
        }

        [Fact]
        public void DollardIsAValidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
            var ch = new CurrencyHolder("Dollard", EXEMPLE_CAPACITE_VALIDE, 0);
        }

        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            var ch = new CurrencyHolder("Dollard", EXEMPLE_CAPACITE_VALIDE, 500);
            ch.Store(10);
            Assert.True(ch.CurrentAmount == 510);
        }

        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
             Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 500, 490);
                ch.Store(20);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption()
        {
            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("EU", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            // A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
            // Asruce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 200);
                ch.Withdraw(-60);
            };
            Assert.Throws<CantWitchDrawMoreThanCurrentAmountException>(mauvaisAppel);
        }
        //#TODO_ETAPE_4 

        [Fact]
        public void testdouzecaracteres()
        {
            // Ecrivez un test pour un nom de douze caracteres
            Action mauvaisAppel = () => new CurrencyHolder("012345678912",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void negativecurrency()
        {
            // On ne peux pas mettre (methode) put une quantité negative de currency dans un CurrencyHolder
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CAPACITE_VALIDE);
                ch.Store(-5);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void currencydepassercapacite()
        {
            // On ne peux pas mettre des currency dans un CurrencyHolder si ca le fait depasser sa capacité
            Action mauvaisAppel = () => 
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 410, 400);
                ch.Store(11);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void ajouter0currency()
        {
            // On ne peux pas ajouter 0 currency (lever expetion)
            Action mauvaisAppel = () => 
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CAPACITE_VALIDE);
                ch.Store(0);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void retirer0currency()
        {
            // On ne peux pas retirer 0 currency (lever expetion)
            Action mauvaisAppel = () => 
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CAPACITE_VALIDE);
                ch.Withdraw(0);
            };
            Assert.Throws<CantWitchDrawMoreThanCurrentAmountException>(mauvaisAppel);
        }

        [Fact]
        public void  lettreAmajuscule()
        {
            // Un nom de currency ne doit pas commencer par la lettre a majuscule
            Action mauvaisAppel = () => new CurrencyHolder("ABCDE",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void  lettreAminuscule()
        {
            // Un nom de currency ne doit pas commencer par la lettre a majuscule
            Action mauvaisAppel = () => new CurrencyHolder("aBCDE",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void capaciteinferieure1positif()
        {
            // Un CurrencyHolder ne peux avoir une capacité inférieure à 1 
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE , 0 , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void capaciteinferieure1negatif()
        {
            // Un CurrencyHolder ne peux avoir une capacité inférieure à 1 
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE , -1 , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CONTENANCE_INITIALE_VIDE()
        {
            // Faire un tests unitaires pertinents pour la methode IsEmpty est vide 
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.IsEmpty();
            Assert.True(result);
        }

        [Fact]
        public void CONTENANCE_INITIALE_NONVIDE()
        {
            // Faire un tests unitaires pertinents pour la methode IsEmpty n'est pas vide 
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 20);
            var result = ch.IsEmpty();
            Assert.False(result);
        }

        [Fact]
        public void contenuEgalcapacite()
        {
            // Un CurrencyHolder est plein contenu est égal à sa capacité 
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 20, 20);
            var result = ch.IsFull();
            Assert.True(result);
        }

        [Fact]
        public void contenuNonEgalcapacite()
        {
            // Un CurrencyHolder n'est pas plein contenu n'est pas égal à sa capacité 
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 25, 20);
            var result = ch.IsFull();
            Assert.False(result);
        }
    }
}