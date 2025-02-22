INSERT INTO PARTS_CATEGORIES (id, name) VALUES
(1, 'CPU'),
(2, 'GPU'),
(3, 'Motherboard'),
(4, 'RAM'),
(5, 'Storage'),
(6, 'PSU'),
(7, 'Cooling System'),
(8, 'Case'),
(9, 'Keyboard'),
(10, 'Trackpad'),
(11, 'Monitor'),
(12, 'Sound Card'),
(13, 'Network Card'),
(14, 'Optical Drive'),
(15, 'Battery'),
(16, 'Fan'),
(17, 'Heat Sink'),
(18, 'Thermal Paste'),
(19, 'Expansion Card'),
(20, 'Speakers');

ALTER SEQUENCE parts_categories_id_seq RESTART WITH 21;

INSERT INTO DEVICES_CATEGORIES (id, name) VALUES
(1, 'Laptop'),
(2, 'Desktop'),
(3, 'Tablet'),
(4, 'Smartphone'),
(5, 'Monitor'),
(6, 'Printer'),
(7, 'Scanner'),
(8, 'Router'),
(9, 'Switch'),
(10, 'Server'),
(11, 'NAS'),
(12, 'Projector'),
(13, 'Camera'),
(14, 'Smartwatch'),
(15, 'VR Headset'),
(16, 'Game Console'),
(17, 'Smart TV'),
(18, 'Smart Speaker'),
(19, 'Smart Home Hub'),
(20, 'External Storage');

ALTER SEQUENCE devices_categories_id_seq RESTART WITH 21;

INSERT INTO SOFTWARE_CATEGORIES (id, name) VALUES
(1, 'Operating System'),
(2, 'Productivity'),
(3, 'Development'),
(4, 'Graphics & Design'),
(5, 'Security'),
(6, 'Utility'),
(7, 'Multimedia'),
(8, 'Education'),
(9, 'Gaming'),
(10, 'Networking'),
(11, 'Database'),
(12, 'Communication'),
(13, 'Finance'),
(14, 'Health & Fitness'),
(15, 'Travel'),
(16, 'Lifestyle'),
(17, 'News & Magazines'),
(18, 'Shopping'),
(19, 'Social'),
(20, 'Weather');

ALTER SEQUENCE software_categories_id_seq RESTART WITH 21;