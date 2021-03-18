SELECT user.name FROM `user`,user_car WHERE user_car.user = user.id and name LIKE "Kis" GROUP BY user_car.user HAVING COUNT(user_car.user) = 0;

SELECT user.name FROM `user`,user_car WHERE user_car.user = user.id GROUP BY user.name HAVING COUNT(user_car.user) > 1;

ALTER TABLE user ADD szig_szam varchar(11);
ALTER TABLE user ADD nem BIT;
--> 1 = férfi, 0 = nő;

INSERT INTO `car`(`brand`, `model`) VALUES ("Volkswagen","Arteon");
--> Nem szükséges az id-t kitölteni az AI miatt.
