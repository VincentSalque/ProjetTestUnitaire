Problématique :
Ajouter la fonctionnalité suivante
 
Produit supplémentaire (Chocolat, Latté, Cappucino) + gobelets
 - Simple : Fourniture d’un gobelet si pas de tasse détectée​
 - Complexe : Produits en plus avec leurs stocks et leur prix
 
Plan de Test :
 - 




Questions :
 - Quel est l'enchainement entre : Sélection de la Boisson - Détection du Gobelet - Insertion des Pièces
        Réponse : Sélection de Boisson PUIS Insertion des pièces PUIS Détection et déploiement des Gobelets (si nécessaire)
 - Comment le prix des gobelets est il compté dans le prix du produit, ajout ou déduction ?
        Réponse : Le prix du gobelet est déduis du prix du @produit à posteriori

CAS SIMPLES :
    //vérification du service si prix de @produit atteint
    ETANT DONNE Une machine a café 
    QUAND on sélectionne @produit
    ET on insére des pièces d'une valeur supérieure ou égal au prix de @produit
    ET qu'on ne présente pas de gobelet
    ALORS @produit est servi et on encaisse l'argent

    //Vérification du service si prix de @produit atteint une fois la déduction de la tasse
    ETANT DONNE Une machine a café 
    QUAND on sélectionne @produit
    ET on insére des pièces d'une valeur supérieure ou égal au prix de @produit moins le prix du gobelet, mais inférieure au prix de @produit
    ET qu'on ne présente pas de gobelet
    ALORS la commande est annulé et l'argent est rendu

    //Vérification de distribution de gobelet si prix de @produit atteint et pas de gobelet
    ETANT DONNE Une machine a café 
    QUAND on sélectionne @produit
    ET on insére des pièces d'une valeur supérieure ou égal au prix de @produit
    ET qu'on ne présente pas de gobelet
    ALORS gobelet est distribué 
    ET @produit est servi

    //Vérification du déni de service si prix de @produit non atteint
    ETANT DONNE Une machine a café
    QUAND On commande un @produit
    ET qu'on insére des pièces d'une valeur inférieure au prix de @produit
    ALORS on rend l'argent et @produit n'est pas servi

    //Vérification du déni de service si prix de @produit non-atteint une fois la déduction de la tasse
    ETANT DONNE Une machine a café 
    QUAND on sélectionne @produit
    ET on insére des pièces d'une valeur inférieure ou égale au prix de @produit moins le prix du gobelet
    ET qu'on présente une tasse
    ALORS la commande est annulé et l'argent est rendu

    //Vérification du reset de @produit entre services
    ETANT DONNE Une machine à café
    QUAND Une commande de @produit à été complétée
    ET qu'on insére des pièces d'une valeur supérieure ou égale au prix du café standard
    ALORS un café standard est servi

CAS AMBIGUES:
    ETANT DONNE Une machine a café
    QUAND on insére des pièces d'une valeur supérieur ou égale au prix du café standard
    ET qu'on ne sélectionne pas de @produit
    ALORS ???       // Réponse : Le café par défaut est servi

    ETANT DONNE Une machine a café
    QUAND on sélectionne un @produit
    ET qu'on insère pas de pièces
    ALORS ???       // Réponse : Pas de gestion du temps, TIMEOUT à ignorer

    ETANT DONNE Une machine a café sans gobelets
    QUAND on sélectionne @produit
    ET on insére des pièces d'une valeur supérieure à égal au prix de @produit
    ET qu'on ne présente pas de tasse
    ALORS ???       //Réponse : On annule la commande ET on rend l'argent

    ETANT DONNE Une machine a café au boiler défectueux
    QAUND on sélectionne @produit
    ET qu'on insére des pièce d'une valeur supérieure ou égale au prix de @produit
    ET qu'on ne présente pas de tasse ET qu'on distribue un gobelet
    ALORS ???       //Réponse : On annule la commande ET on rend TOUT l'argent (pas de déduction du prix du gobelet)

    ETANT DONNE Une machine a café
    QUAND On commande un @produit dont la valeur est inférieure au prix du gobelet
    ET On présente une tasse, dont la déduction comppense le prix du @produit
    ALORS ???       //Réponse : Cas Impossible - non géré

    ETANT DONNE Une machine à café dont le stock de @produit est vide
    QUAND on sélectionne @produit
    ET on insére des pièces d'une valeur supérieure à égal au prix de @produit
    ALORS ???       //Réponse : On annule la commande et on rend les pièces (On agit comme si les pièces étaient dans le réceptacle au moment de la commande, pour ne pas avoir à gérer un timer)


