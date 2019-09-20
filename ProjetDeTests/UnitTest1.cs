using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelObjet;

namespace ProjetDeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void ValiderTest()
        {

            // Le nombre de jours d'achat est < à 30 jours
            bool a = Condition.Valider(25);
            Assert.AreEqual(true, a);

            // Le nombre de jours d'achat est > à 30 jours
            bool b = Condition.Valider(50);
            Assert.AreEqual(false, b);
        }

        [TestMethod()]
        public void CalculerMontantMaxTest()
        {
            // Pour la catégorie livre
            int a = Condition.CalculerMontantMax("Livres");
            Assert.AreEqual(30, a);

            // Pour la catégorie jouet
            int b = Condition.CalculerMontantMax("Jouets");
            Assert.AreEqual(50, b);

            // Pour la catégorie informatique
            int c = Condition.CalculerMontantMax("Informatique");
            Assert.AreEqual(1000, c);
        }

        [TestMethod()]
        public void CalculerMontantRembourseTest()
        {
            // Un livre achété 24 euros depuis 15 jours avec un état "Très abimé" en étant non membre
            double a = Condition.CalculerMontantRembourse(15, "Livres", false, "Très abimé", 24);
            Assert.AreEqual(24, a);
            // Un livre achété 24 euros depuis 15 jours avec un état "Bon" en étant membre
            double b = Condition.CalculerMontantRembourse(15, "Livres", true, "Bon", 24);
            

            double c = Condition.CalculerMontantRembourse(20, "Livres", true, "Abimé", 50);
            Assert.AreEqual(21, c);
        }

        [TestMethod()]
        public void CalculerReductionMembreTest()
        {
            // Il est membre
            double a = Condition.CalculerReductionMembre(true);
            Assert.AreEqual(0, a);

            // Il n'est pas membre
            double b = Condition.CalculerReductionMembre(false);
            Assert.AreEqual(0.2, b);

        }

        [TestMethod()]
        public void CalculerReductionTest()
        {
            // Pour un état "bon"
            double a = Condition.CalculerReduction("Bon");
            Assert.AreEqual(0.1, a);

            // Pour un état "abimé"
            double b = Condition.CalculerReduction("Abimé");
            Assert.AreEqual(0.3, b);
            

        }
    }
}
