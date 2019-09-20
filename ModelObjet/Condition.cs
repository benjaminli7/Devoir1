using System;

namespace ModelObjet
{
    public class Condition
    {
        const int nbJours = 30;
        // Permet de savoir si on a le droit d'être remboursé
        // On l'est à condition que le nombre de jours ne dépasse pas 30 !
        public static bool Valider(int unNbDeJours)
        {
            if(unNbDeJours < nbJours)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
        // Permet de renvoyer le montant MAX remboursé en fonction de la catégorie
        public static int CalculerMontantMax(string uneCategorie)
        {
            if(uneCategorie == "Livres")
            {
                return 30;
            }
            else if(uneCategorie == "Jouets")
            {
                return 50;
            }
            else if(uneCategorie == "Informatique")
            {
                return 1000;
            }
            else
            {
                return 0;
            }
        }
        // Permet de retourner le total remboursé en fonction de tous les critères
        public static double CalculerMontantRembourse(int unNbDeJours, string uneCategorie, bool estMembre, string unEtat, int unPrix)
        {
            double prixFinal = 0;
            if (Condition.Valider(unNbDeJours) == true)
            {
                if(unPrix > CalculerMontantMax(uneCategorie))
                {
                    
                    double reductionMembre = CalculerReductionMembre(estMembre);
                    double reduction = CalculerReduction(unEtat);
                    prixFinal = CalculerMontantMax(uneCategorie) * (1 - (reductionMembre + reduction));
                    return prixFinal;
                }
                prixFinal = unPrix;
                return prixFinal;
            }
            else
            {
                return prixFinal;
            }
        }
        // Permet de renvoyer la réduction si on est membre ou pas
        public static double CalculerReductionMembre(bool estMembre)
        {
            double reductionMembre;
            if (estMembre)
            {
                reductionMembre = 0;
            }
            else
            {
                reductionMembre = 0.20;
            }
            return reductionMembre;
        }
        // Permet de renvoyer la réduction en fonction de l'état de l'achat
        public static double CalculerReduction(string unEtat)
        {
            double reduction;
            if (unEtat == "Abimé" || unEtat == "Très abimé")
            {
                reduction = 0.30;
            }
            else
            {
                reduction = 0.10;   
            }
            return reduction;
        }
    }
}
