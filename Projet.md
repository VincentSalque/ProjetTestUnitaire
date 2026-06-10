//Quand on paye mais sans tasse
ETANT DONNE une machine a café

QUAND aucune tasse detectée

ALORS (servir un gobelet)
ET (faire payer plus)



//Quand on paye avec une tasse
ETANT DONNE un tasse detecté

QUAND argent suffisant

ALORS servir un café


//Quand on paye sans tasse MAIS qu'il n'y en a plus
ETANT DONNE une machine a café 

QUAND aucune tasse detectée

ET aucun gobelet restant dans machine a café

ALORS






//Quand on met pas assez d'argent et que on a pas de gobelet
ETANT DONNE une machine a café

QUAND argent insufisant 
ET pas de tasse detectée

ALORS (donner un gobelet)
ET (Rendre la monnaie)