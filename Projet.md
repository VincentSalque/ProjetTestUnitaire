Feature E : Produits supplémentaires (chocolat, latté, cappucino) + gobelets​
- Simple : Fourniture d’un gobelet si pas de tasse détectée​
- Complexe : Produits en plus avec leurs stocks et leur prix

============================================================ Plan de test ====================================================

Fonctionnel :   L'exactitude acceptance test-first. Complétude Manuel test-last. Aptitude à l'usage pour verifier si on a bien le bon café commandé. Test-last unit + acceptance + integration.

Performance :   Temps de réponse. Last-test ou en defect-testing (si la machine met trop de temps a servir le café par exemple)

Compatibilité : Seul sur l'env donc non a la limite avec le hardware ou le système de paiement bancaire. Test-Last ou Test-First pour le paiement

Utilisabilité : Ergonomique pour l'utilisateur et protection contre les erreurs (Mauvais café sélectionné, afficher que ce que doit voir l'utilisateur. Test-Last

Fiabilité :     Robustesse quand l'utilisateur a un défaut de paiement ou le code du cafe est incorrecte. Test-last

Sécurité :      Le Rejet/Non Rejet (pour le paiement aussi j'aurais dit) et l'Authenticité pour voir si on communique bien au TPE pour le paiement. Test-Last pour rejet et Test-First authenticité. Conseillé pour un vrai projet

Maintenabilité : Manuel ou Defect testing pour un potentiel changement de Hardware

Portabilité :   Non car c'est sur son propre environnement, c'est le code d'une seule machine avec des specs défini.


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
Je veux etre informe du stock des gobelets.

US5 - Money Insuffisante et pas de tasse

========================================================== GERKIN ==================================================