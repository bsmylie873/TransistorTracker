INSERT INTO USERS (id, username, email, avatar, user_type_id) VALUES
(1, 'john_doe', 'john.doe@example.com', 'john_avatar.png', 1),
(2, 'jane_smith', 'jane.smith@example.com', 'jane_avatar.png', 2),
(3, 'alice_jones', 'alice.jones@example.com', 'alice_avatar.png', 3),
(4, 'bob_brown', 'bob.brown@example.com', 'bob_avatar.png', 1),
(5, 'carol_white', 'carol.white@example.com', 'carol_avatar.png', 2),
(6, 'dave_black', 'dave.black@example.com', 'dave_avatar.png', 3),
(7, 'eve_green', 'eve.green@example.com', 'eve_avatar.png', 1),
(8, 'frank_blue', 'frank.blue@example.com', 'frank_avatar.png', 2),
(9, 'grace_red', 'grace.red@example.com', 'grace_avatar.png', 3),
(10, 'heidi_yellow', 'heidi.yellow@example.com', 'heidi_avatar.png', 1);

ALTER SEQUENCE users_id_seq RESTART WITH 11;

INSERT INTO LOCATIONS (id, name, avatar, house_number, street, city, state, postal_code, country) VALUES
(1, 'Headquarters', 'hq_avatar.png', '123', 'Main St', 'Metropolis', 'NY', '10001', 'USA'),
(2, 'Branch Office', 'branch_avatar.png', '456', 'Second St', 'Gotham', 'NJ', '07001', 'USA'),
(3, 'Warehouse', 'warehouse_avatar.png', '789', 'Third St', 'Star City', 'CA', '90001', 'USA'),
(4, 'Remote Office', 'remote_avatar.png', '101', 'Fourth St', 'Central City', 'IL', '60001', 'USA'),
(5, 'Data Center', 'datacenter_avatar.png', '202', 'Fifth St', 'Coast City', 'TX', '70001', 'USA'),
(6, 'Research Lab', 'lab_avatar.png', '303', 'Sixth St', 'Blüdhaven', 'FL', '80001', 'USA'),
(7, 'Support Center', 'support_avatar.png', '404', 'Seventh St', 'Fawcett City', 'OH', '90001', 'USA'),
(8, 'Training Facility', 'training_avatar.png', '505', 'Eighth St', 'Keystone City', 'PA', '10002', 'USA'),
(9, 'Sales Office', 'sales_avatar.png', '606', 'Ninth St', 'Opal City', 'GA', '20001', 'USA'),
(10, 'Marketing Office', 'marketing_avatar.png', '707', 'Tenth St', 'Gateway City', 'WA', '30001', 'USA');

ALTER SEQUENCE locations_id_seq RESTART WITH 11;

INSERT INTO DEVICES (id, name, avatar, model, wattage, colour, wireless, release_date, user_id, location_id, condition_id, status_id, category_id) VALUES
(1, 'MacBook Pro', 'macbook_avatar.png', 'MBP2021', 100, 'Space Gray', true, '2022-01-01', 1, 1, 1, 1, 1),
(2, 'Dell XPS 13', 'dell_avatar.png', 'XPS13', 200, 'Silver', false, '2022-02-01', 2, 2, 2, 2, 2),
(3, 'HP Spectre x360', 'hp_avatar.png', 'Spectre2021', 150, 'Black', true, '2022-03-01', 3, 2, 1, 1, 1),
(4, 'Lenovo ThinkPad X1', 'lenovo_avatar.png', 'ThinkPadX1', 180, 'Black', false, '2022-04-01', 4, 4, 2, 2, 2),
(5, 'Microsoft Surface Pro', 'surface_avatar.png', 'SurfacePro7', 120, 'Platinum', true, '2022-05-01', 5, 5, 1, 1, 1),
(6, 'Asus ZenBook', 'asus_avatar.png', 'ZenBook2021', 130, 'Blue', true, '2022-06-01', 1, 1, 2, 2, 2),
(7, 'Acer Swift 3', 'acer_avatar.png', 'Swift32021', 140, 'Silver', false, '2022-07-01', 2, 2, 1, 1, 1),
(8, 'Razer Blade 15', 'razer_avatar.png', 'Blade152021', 220, 'Black', true, '2022-08-01', 3, 3, 2, 2, 2),
(9, 'Apple iMac', 'imac_avatar.png', 'iMac2021', 250, 'Silver', false, '2022-09-01', 4, 4, 1, 1, 1),
(10, 'Google Pixelbook', 'pixelbook_avatar.png', 'Pixelbook2021', 110, 'White', true, '2022-10-01', 5, 5, 2, 2, 2),
(11, 'Samsung Galaxy Book', 'galaxybook_avatar.png', 'GalaxyBook2021', 160, 'Gray', true, '2022-11-01', 1, 1, 1, 1, 1),
(12, 'LG Gram', 'lggram_avatar.png', 'Gram2021', 170, 'White', false, '2022-12-01', 2, 2, 2, 2, 2),
(13, 'Huawei MateBook X', 'matebook_avatar.png', 'MateBookX2021', 180, 'Silver', true, '2023-01-01', 3, 3, 1, 1, 1),
(14, 'Sony VAIO', 'vaio_avatar.png', 'VAIO2021', 190, 'Black', false, '2023-02-01', 4, 4, 2, 2, 2),
(15, 'Toshiba Dynabook', 'dynabook_avatar.png', 'Dynabook2021', 200, 'Blue', true, '2023-03-01', 5, 5, 1, 1, 1),
(16, 'Alienware M15', 'alienware_avatar.png', 'M152021', 210, 'Black', false, '2023-04-01', 1, 1, 2, 2, 2),
(17, 'MSI Prestige 14', 'msi_avatar.png', 'Prestige142021', 220, 'White', true, '2023-05-01', 2, 2, 1, 1, 1),
(18, 'Google Chromebook', 'chromebook_avatar.png', 'Chromebook2021', 230, 'Silver', false, '2023-06-01', 3, 3, 2, 2, 2),
(19, 'HP Envy', 'envy_avatar.png', 'Envy2021', 240, 'Black', true, '2023-07-01', 4, 4, 1, 1, 1),
(20, 'Dell Inspiron', 'inspiron_avatar.png', 'Inspiron2021', 250, 'Gray', false, '2023-08-01', 5, 5, 2, 2, 2);

ALTER SEQUENCE devices_id_seq RESTART WITH 21;

INSERT INTO PARTS (id, name, avatar, description, wattage, colour, release_date, device_id, user_id, location_id, category_id, condition_id, status_id) VALUES
(1, 'Intel i7 CPU', 'cpu_avatar.png', '8th Gen Intel Core i7', 50, 'Silver', '2022-01-01', 1, 1, 1, 1, 1, 1),
(2, 'NVIDIA GTX 1050', 'gpu_avatar.png', 'NVIDIA GeForce GTX 1050', 75, 'Black', '2022-02-01', 2, 2, 2, 2, 2, 1),
(3, 'Samsung SSD 1TB', 'ssd_avatar.png', 'Samsung 1TB SSD', 5, 'Black', '2022-03-01', 3, 3, 3, 3, 3, 2),
(4, 'Corsair RAM 16GB', 'ram_avatar.png', 'Corsair 16GB RAM', 10, 'Black', '2022-04-01', 4, 4, 4, 4, 2, 1),
(5, 'Intel i9 CPU', 'cpu_i9_avatar.png', '10th Gen Intel Core i9', 65, 'Silver', '2022-05-01', 5, 5, 5, 5, 2, 2),
(6, 'AMD Ryzen 7', 'ryzen_avatar.png', 'AMD Ryzen 7 3700X', 65, 'Silver', '2022-06-01', NULL, 1, 1, 1, 1, 1),
(7, 'Kingston RAM 8GB', 'ram_kingston_avatar.png', 'Kingston 8GB RAM', 10, 'Black', '2022-07-01', NULL, 2, 2, 2, 2, 2),
(8, 'Seagate HDD 2TB', 'hdd_avatar.png', 'Seagate 2TB HDD', 15, 'Black', '2022-08-01', 6, 1, 1, 1, 1, 1),
(9, 'NVIDIA RTX 3080', 'rtx_avatar.png', 'NVIDIA GeForce RTX 3080', 320, 'Black', '2022-09-01', 7, 2, 2, 2, 2, 2),
(10, 'Crucial SSD 500GB', 'ssd_crucial_avatar.png', 'Crucial 500GB SSD', 5, 'Black', '2022-10-01', 8, 3, 3, 3, 3, 1),
(11, 'Intel i5 CPU', 'cpu_i5_avatar.png', '9th Gen Intel Core i5', 65, 'Silver', '2022-11-01', 9, 4, 4, 4, 3, 1),
(12, 'AMD Radeon RX 580', 'radeon_avatar.png', 'AMD Radeon RX 580', 185, 'Black', '2022-12-01', 10, 5, 5, 5, 2, 1),
(13, 'HyperX RAM 32GB', 'ram_hyperx_avatar.png', 'HyperX 32GB RAM', 10, 'Black', '2023-01-01', 11, 1, 1, 1, 1, 1),
(14, 'Western Digital HDD 1TB', 'hdd_wd_avatar.png', 'Western Digital 1TB HDD', 10, 'Black', '2023-02-01', 12, 2, 2, 2, 2, 2),
(15, 'Asus Motherboard', 'motherboard_avatar.png', 'Asus ROG Strix B450-F', 50, 'Black', '2023-03-01', NULL, 3, 3, 3, 3, 2);

ALTER SEQUENCE parts_id_seq RESTART WITH 16;

INSERT INTO SOFTWARE (id, name, avatar, version, release_date, category_id) VALUES
(1, 'Windows 10', 'windows_avatar.png', '10.0', '2022-01-01', 1),
(2, 'Adobe Photoshop', 'photoshop_avatar.png', '2022', '2022-02-01', 2),
(3, 'Ubuntu', 'ubuntu_avatar.png', '20.04', '2022-03-01', 1),
(4, 'macOS Big Sur', 'macos_avatar.png', '11.0', '2022-04-01', 1),
(5, 'Fedora', 'fedora_avatar.png', '34', '2022-05-01', 1),
(6, 'Debian', 'debian_avatar.png', '10', '2022-06-01', 1),
(7, 'Red Hat Enterprise Linux', 'rhel_avatar.png', '8', '2022-07-01', 1),
(8, 'CentOS', 'centos_avatar.png', '8', '2022-08-01', 1),
(9, 'Arch Linux', 'arch_avatar.png', '2022.01.01', '2022-09-01', 1),
(10, 'Kali Linux', 'kali_avatar.png', '2022.2', '2022-10-01', 1),
(11, 'Linux Mint', 'mint_avatar.png', '20.2', '2022-11-01', 1),
(12, 'Elementary OS', 'elementary_avatar.png', '6.0', '2022-12-01', 1),
(13, 'Zorin OS', 'zorin_avatar.png', '16', '2023-01-01', 1),
(14, 'Manjaro', 'manjaro_avatar.png', '21.1', '2023-02-01', 1),
(15, 'openSUSE', 'opensuse_avatar.png', '15.3', '2023-03-01', 1);

ALTER SEQUENCE software_id_seq RESTART WITH 16;

INSERT INTO REVIEWS (id, review_text, rating, user_id, device_id, part_id) VALUES
(1, 'Excellent compatibility with my system.', 9, 1, 1, NULL),
(2, 'Good compatibility but some minor issues.', 7, 2, NULL, 1),
(3, 'Very reliable and fast on my device.', 8, 3, 2, NULL),
(4, 'Not compatible with my system.', 4, 4, NULL, 2),
(5, 'Great for gaming, no compatibility issues.', 9, 5, 3, NULL),
(6, 'Easy to install and use, fully compatible.', 8, 6, NULL, 3),
(7, 'Highly recommend for professionals, works flawlessly.', 10, 7, 4, NULL),
(8, 'Affordable and efficient, compatible with most systems.', 7, 8, NULL, 4),
(9, 'Excellent customer support for compatibility issues.', 9, 9, 5, NULL),
(10, 'Not as described, compatibility issues.', 3, 10, NULL, 5),
(11, 'Perfect for my needs, no compatibility problems.', 10, 1, 6, NULL),
(12, 'Could be better, some compatibility issues.', 6, 2, NULL, 6),
(13, 'Fantastic performance, fully compatible.', 9, 3, 7, NULL),
(14, 'Very satisfied with the compatibility.', 8, 4, NULL, 7),
(15, 'Would use again, no compatibility issues.', 9, 5, 8, NULL);

ALTER SEQUENCE reviews_id_seq RESTART WITH 16;

INSERT INTO SOFTWARE_COMPATIBILITIES (id, software_id, part_id, device_id, software_compatibility_level_id) VALUES
(1, 1, 1, NULL, 1),
(2, 1, NULL, 2, 2),
(3, 2, 1, NULL, 1),
(4, 2, NULL, 2, 3),
(5, 3, 1, NULL, 1),
(6, 3, NULL, 2, 2),
(7, 4, 1, NULL, 1),
(8, 4, NULL, 2, 3),
(9, 5, 1, NULL, 1),
(10, 5, NULL, 2, 2),
(11, 6, 1, NULL, 1),
(12, 6, NULL, 2, 3),
(13, 7, 1, NULL, 1),
(14, 7, NULL, 2, 2),
(15, 8, 1, NULL, 1),
(16, 8, NULL, 2, 3),
(17, 9, 1, NULL, 1),
(18, 9, NULL, 2, 2),
(19, 10, 1, NULL, 1),
(20, 10, NULL, 2, 3),
(21, 11, 1, NULL, 1),
(22, 11, NULL, 2, 2),
(23, 12, 1, NULL, 1),
(24, 12, NULL, 2, 3),
(25, 13, 1, NULL, 1),
(26, 13, NULL, 2, 2),
(27, 14, 1, NULL, 1),
(28, 14, NULL, 2, 3),
(29, 15, 1, NULL, 1),
(30, 15, NULL, 2, 2);

ALTER SEQUENCE software_compatibilities_id_seq RESTART WITH 31;