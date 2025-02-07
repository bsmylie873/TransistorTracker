CREATE TABLE SOFTWARE_COMPATIBILITY_LEVELS (
    id SERIAL CONSTRAINT software_compatibility_levels_id PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(255)
);

CREATE TABLE SOFTWARE_COMPATIBILITIES (
    id SERIAL CONSTRAINT software_compatibilities_id PRIMARY KEY,
    software_id INT NOT NULL,
    part_id INT,
    device_id INT,
    software_compatibility_level_id INT NOT NULL,
    created_date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    modified_date TIMESTAMP,
    FOREIGN KEY (software_id) REFERENCES SOFTWARE(id),
    FOREIGN KEY (part_id) REFERENCES PARTS(id),
    FOREIGN KEY (device_id) REFERENCES DEVICES(id),
    FOREIGN KEY (software_compatibility_level_id) REFERENCES SOFTWARE_COMPATIBILITY_LEVELS(id)
);