CREATE TABLE CarDetails (
	car_id int IDENTITY(1,1) PRIMARY KEY,
	Make varchar(255),
	Model varchar(255),
	Year int,
	URL varchar(MAX)
);

INSERT INTO CarDetails(Make, Model, Year, URL)
VALUES ('Buick', 'Lacrosse', 2009, 'https://cdn05.carsforsale.com/00dfd59ebe40f1b84bd2bdc58ab1202830/800x600/2009-buick-lacrosse-cx-4dr-sedan.jpg');

INSERT INTO CarDetails(Make, Model, Year, URL)
VALUES ('Kia', 'Soul', 2016, 'https://file.kelleybluebookimages.com/kbb/base/evox/CP/10730/2016-Kia-Soul-front_10730_032_1881x931_A3D_cropped.png');

INSERT INTO CarDetails(Make, Model, Year, URL)
OUTPUT INSERTED.car_id
VALUES ('Ford', 'Taurus', 2011, 'https://static01.nyt.com/images/2009/08/28/realestate/30taurus_pan.jpg?quality=75&auto=webp&disable=upscale');

SELECT * FROM CarDetails
WHERE car_id = 2

UPDATE CarDetails
SET Make = 'Kia'
WHERE car_id = 2