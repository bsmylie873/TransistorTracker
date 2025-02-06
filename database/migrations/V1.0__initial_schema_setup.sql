CREATE TABLE USER_TYPES (
    id SERIAL CONSTRAINT user_types_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE USERS (
    id SERIAL CONSTRAINT users_id PRIMARY KEY,
    username VARCHAR(255) NOT NULL UNIQUE,
    email VARCHAR(255) NOT NULL UNIQUE,
    avatar VARCHAR(255),
    created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    modified_date TIMESTAMP,
    user_type_id INT NOT NULL,
    FOREIGN KEY (user_type_id) REFERENCES USER_TYPES(id)
);

CREATE TABLE LOCATIONS (
    id SERIAL CONSTRAINT locations_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    avatar VARCHAR(255),
    house_number VARCHAR(20),
    street VARCHAR(255),
    city VARCHAR(255),
    state VARCHAR(255),
    postal_code VARCHAR(20),
    country VARCHAR(255),
    created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    modified_date TIMESTAMP,
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES USERS(id)
);

CREATE TABLE HARDWARE_CONDITIONS (
    id SERIAL CONSTRAINT hardware_conditions_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE HARDWARE_STATUSES (
    id SERIAL CONSTRAINT hardware_statuses_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE DEVICES_CATEGORIES (
    id SERIAL CONSTRAINT device_categories_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE DEVICES (
    id SERIAL CONSTRAINT devices_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    avatar VARCHAR(255),
    model VARCHAR(255) NOT NULL,
    wattage INT,
    colour VARCHAR(50),
    wireless BOOLEAN,
    release_date DATE,
    created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    modified_date TIMESTAMP,
    user_id INT NOT NULL,
    location_id INT,
    condition_id INT NOT NULL,
    status_id INT NOT NULL,
    category_id INT NOT NULL,
    FOREIGN KEY (category_id) REFERENCES DEVICES_CATEGORIES(id),
    FOREIGN KEY (user_id) REFERENCES USERS(id),
    FOREIGN KEY (location_id) REFERENCES LOCATIONS(id),
    FOREIGN KEY (condition_id) REFERENCES HARDWARE_CONDITIONS(id),
    FOREIGN KEY (status_id) REFERENCES HARDWARE_STATUSES(id)
);

CREATE TABLE PARTS_CATEGORIES (
    id SERIAL CONSTRAINT parts_categories_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE PARTS (
    id SERIAL CONSTRAINT parts_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    avatar VARCHAR(255),
    description TEXT,
    wattage INT,
    colour VARCHAR(50),
    release_date DATE,
    created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    modified_date TIMESTAMP,
    device_id INT,
    user_id INT NOT NULL,
    location_id INT,
    category_id INT NOT NULL,
    condition_id INT NOT NULL,
    status_id INT NOT NULL,
    FOREIGN KEY (device_id) REFERENCES DEVICES(id),
    FOREIGN KEY (user_id) REFERENCES USERS(id),
    FOREIGN KEY (location_id) REFERENCES LOCATIONS(id),
    FOREIGN KEY (category_id) REFERENCES PARTS_CATEGORIES(id),
    FOREIGN KEY (condition_id) REFERENCES HARDWARE_CONDITIONS(id),
    FOREIGN KEY (status_id) REFERENCES HARDWARE_STATUSES(id)
);

CREATE TABLE SOFTWARE_CATEGORIES (
    id SERIAL CONSTRAINT software_categories_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE SOFTWARE (
    id SERIAL CONSTRAINT software_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    avatar VARCHAR(255),
    version VARCHAR(50),
    release_date DATE,
    category_id INT NOT NULL,
    FOREIGN KEY (category_id) REFERENCES SOFTWARE_CATEGORIES(id)
);

CREATE TABLE REVIEWS (
    id SERIAL CONSTRAINT reviews_id PRIMARY KEY,
    review_text TEXT,
    rating INT CHECK (rating >= 0 AND rating <= 10),
    created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    modified_date TIMESTAMP,
    user_id INT NOT NULL,
    device_id INT,
    part_id INT,
    FOREIGN KEY (user_id) REFERENCES USERS(id),
    FOREIGN KEY (device_id) REFERENCES DEVICES(id),
    FOREIGN KEY (part_id) REFERENCES PARTS(id)
);