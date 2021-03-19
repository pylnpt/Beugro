SELECT user.name FROM `user`,user_car WHERE user_car.user = user.id and name LIKE "Kis%" GROUP BY user_car.user HAVING COUNT(user_car.user) = 0;

SELECT user.name FROM `user`,user_car WHERE user_car.user = user.id GROUP BY user.name HAVING COUNT(user_car.user) > 1;

ALTER TABLE user
ADD nem bool;
ALTER TABLE user
ADD szemelyi_szam varchar(11);

INSERT INTO `car`(`brand`, `model`) VALUES ("Volkswagen","Arteon");

UPDATE car SET model="Fiesta" WHERE model="Focus";

INSERT INTO `user_car`(`user`, `car`) 
    SELECT id,(SELECT id FROM `car` where brand="Volkswagen" and model="Arteon")
	FROM `user` where id < 10 and (name LIKE "%o%" or name LIKE "%r%");
    
ALTER TABLE user_car ADD uid varchar(12);
UPDATE `user_car` SET `uid`=(SELECT CONCAT(FLOOR(12345 + RAND() * 6789), "-ID") AS kulcs
FROM user_car LIMIT 1) WHERE "kulcs" NOT IN (SELECT uid FROM user_car);