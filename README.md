# Projet BoVoyage JessyThomas


##Travail réalisé

####Création de la partie back-office
 - création des class models pour une réalisation en code first
 - création de la base de données d'après le modèle des class models
 - relier bdd et partie c# (connexion, EF, DBContext, Migrations)
 - création des controllers avec la méthode en scaffolding
 - validation des routes et des méthodes CRUD via Postman
 - mise en place de la documentation via Swagger
 - les controllers et leurs routes ont été testé et sont fonctionnels (testé avec des valeurs au bon format et des valeurs avec un mauvais format)
 
####Création de la partie Front-Office
 - création de la structure du site (1 page principale et des dossiers correspondants aux classes models, chaque dossier ayant une page pour chacune des méthodes du CRUD)
 - création d'un menu de type navbar via bootstrap pour faciliter la navigation entre les pages
 - création d'un formulaire pour chacune des pages afin de leur permettre de récupérer les valeurs renvoyées au server
 - création des scripts permettant d'accéder au controller désiré et à l'action CRUD désirée
 - mise en place d'éléments permettant d'obliger la saisie des champs, la saisie de valeurs positives sur les prix, de masquer l'affichage des données bancaires pour l'utilisateur
 - rendre les pages html responsive via bootstrap
 
##Travail à faire
 - L'application ne calcule pas les âges ou les prix automatiquement
 - Divers problèmes d'alignement des div
 - Après inspection de l'ensemble des pages html, à cette heure (18h30) les pages suivantes ne sont pas opérationnelles : 
  *VoyagePut et ParticipantPost : il semble que le format de date récupéré par le client soit en conflit avec l'insertion sur le serveur. La même méthode a été utilisée sur les fichiers clients et ne pose pas de problèmes
  *ClientPost : les dropdowns du menu ne fonctionnent pas
  *ReservationDelete : le menu navbar chevauche le formulaire
 - Automatiser la saisie du champ createdAt
 - Formaliser le readme.md
  
 
