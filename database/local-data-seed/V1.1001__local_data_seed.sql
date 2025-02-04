INSERT INTO USERS (id, username, email, avatar, user_type_id) VALUES
(1, 'john_doe', 'john.doe@example.com', 'john_avatar.png', 1),
(2, 'jane_smith', 'jane.smith@example.com', 'jane_avatar.png', 2),
(3, 'alice_jones', 'alice.jones@example.com', 'alice_avatar.png', 3);

INSERT INTO LOCATIONS (id, name, avatar, house_number, street, city, state, postal_code, country) VALUES
(1, 'Headquarters', 'hq_avatar.png', '123', 'Main St', 'Metropolis', 'NY', '10001', 'USA'),
(2, 'Branch Office', 'branch_avatar.png', '456', 'Second St', 'Gotham', 'NJ', '07001', 'USA');

INSERT INTO DEVICES (id, name, avatar, model, wattage, colour, wireless, release_date, user_id, location_id, condition_id, status_id, category_id) VALUES
(1, 'MacBook Pro', 'macbook_avatar.png', 'MBP2021', 100, 'Space Gray', true, '2022-01-01', 1, 1, 1, 1, 1),
(2, 'Dell XPS 13', 'dell_avatar.png', 'XPS13', 200, 'Silver', false, '2022-02-01', 2, 2, 2, 2, 2);

INSERT INTO PARTS (id, name, avatar, description, wattage, colour, release_date, device_id, user_id, location_id, category_id, condition_id, status_id) VALUES
(1, 'Intel i7 CPU', 'cpu_avatar.png', '8th Gen Intel Core i7', 50, 'Silver', '2022-01-01', 1, 1, 1, 1, 1, 1),
(2, 'NVIDIA GTX 1050', 'gpu_avatar.png', 'NVIDIA GeForce GTX 1050', 75, 'Black', '2022-02-01', 2, 2, 2, 2, 2, 2);

INSERT INTO SOFTWARE (id, name, avatar, version, release_date, category_id) VALUES
(1, 'Windows 10', 'windows_avatar.png', '10.0', '2022-01-01', 1),
(2, 'Adobe Photoshop', 'photoshop_avatar.png', '2022', '2022-02-01', 2);

INSERT INTO REVIEWS (id, review_text, rating, user_id, device_id, part_id) VALUES
(1, 'Excellent performance and build quality.', 9, 1, 1, NULL),
(2, 'Good value for the price.', 7, 2, NULL, 1);