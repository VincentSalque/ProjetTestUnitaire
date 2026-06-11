Feature E : Produits supplémentaires (chocolat, latté, cappucino) + gobelets​
- Simple : Fourniture d’un gobelet si pas de tasse détectée​
- Complexe : Produits en plus avec leurs stocks et leur prix

============================================================ Plan de test ====================================================

Fonctionnel :   
L'exactitude acceptance test-first.
Complétude Manuel test-last. 
Aptitude à l'usage pour verifier si on a bien le bon café commandé. Test-last unit + acceptance + integration.

Performance :   
Temps de réponse Last-test ou en defect-testing (si la machine met trop de temps a servir le café par exemple)
Utilisation de ressource non
Capacité non

Compatibilité : 
Coexistance Seul sur l'env donc non a la limite avec le hardware ou le système de paiement bancaire. (Test-Last ou Test-First pour le paiement)
Interopérabilité non

Utilisabilité : Ergonomique pour l'utilisateur et protection contre les erreurs (Mauvais café sélectionné, afficher que ce que doit voir l'utilisateur. Test-Last) ou Manuel car il n'y pas d'interface

Fiabilité :     
Maturité non
Dispo non
Robustesse quand l'utilisateur a un défaut de paiement ou le code du cafe est incorrecte. Test-last
recup non

Sécurité :      Non pour tout (Le Rejet/Non Rejet (pour le paiement aussi j'aurais dit) et l'Authenticité pour voir si on communique bien au TPE pour le paiement. Test-Last pour rejet et Test-First authenticité. Conseillé pour un vrai projet)

Maintenabilité : Manuel ou Defect testing pour un potentiel changement de Hardware

Portabilité :   Manul ou Non car c'est sur son propre environnement, c'est le code d'une seule machine avec des specs défini.


========================================================== User story ================================================= 

US1 - Fourniture de gobelet par défaut
En tant qu'utilisateur ne possédant pas de tasse.
Je veux que la machine me fournisse automatiquement un gobelet avant de faire couler le café.

US2 - Utilisation de ma propre tasse
En tant qu'utilisateur possédant ma propre tasse.
Je veux que la machine détecte la présence de ma tasse avant de faire couler un café.

US3 - Gobelet bien arrivé
En tant que gérant de la machine.
Je veux que le système vérifie qu'un gobelet a bien été distribué.

US4 - Stock des Gobelets
En tant qu'utilisateur ne possedant pas de tasse.
Je veux etre informé du stock des gobelets.

US5 - Money Insuffisante et pas de tasse

========================================================== GERKIN ==================================================
Cas 1 : Tasse + Assez Argent
    ETANT DONNE Une machine a café 
    
    QUAND on insére une somme suffisante
    ET qu'on présente de tasse
    
    ALORS on coule un café 
    ET on encaisse l'argent

Cas 2 : Tasse + Pas assez Argent
    ETANT DONNE Une machine a café

    QUAND on insere une somme insuffisante malgré la réduction pour avoir une tasse
    ET qu'on a une tasse
    
    ALORS on ne coule un café 
    ET l'argent est rendu

cas 3 : Gobelet + Assez Argent

    ETANT DONNE Une machine a café 

    QUAND on insére une somme suffisante
    ET qu'on ne présente pas de tasse

    ALORS gobelet est distribué 
    ET un café coule 
    ET on encaisse l'argent

cas 4 : Gobelet + Pas assez Argent

    ETANT DONNE Une machine a café

    QUAND on insére une somme insuffisante
    ET on ne présente pas de tasse

    ALORS on rend l'argent 
    ET on ne coule pas de café
    ET on ne sert pas de gobelet

cas 5 : Somme insuffisante avec gobelet mais pas avec tasse

    ETANT DONNE Une machine a café 
    QUAND on insére une somme suffisante moins le a réduction de la tasse
    ET qu'on présente une tasse

    ALORS la commande est annulé 
    ET l'argent est rendu


cas 6 : Pas de tasse + plus de stock de gobelet + assez d'argent

    ETANT DONNE Une machine a café

    QUAND on insere une somme suffisante
    ET on ne présente pas de tasse
    ET la machine n'a plus de gobelet

    ALORS  (Prof : on rend la monnaie)

cas 7 : Cas ou on fait rien
    ETANT DONNE Une machine a café

    QUAND qu'on insère RIEN
    
    ALORS (prof : rien, pas de gestion de time out)


cas Adrien : Par rapport a la réduction de prix pour avoir une tasse et le remboursement 

    ETANT DONNE Une machine a café avec un probleme de Brewer
    QUAND on insére une somme suffisante
    ET qu'on ne présente pas de tasse 
    ET qu'on distribue un gobelet

    ALORS (prof : on rend l'argent inseré et il aura un gobelet gratuit)

 