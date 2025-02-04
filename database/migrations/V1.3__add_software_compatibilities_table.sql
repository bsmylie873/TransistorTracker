CREATE TABLE SOFTWARE_COMPATIBILITY_LEVELS (
    id INT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
);

CREATE TABLE SOFTWARE_COMPATIBILITIES (
    id INT PRIMARY KEY,
    software_id INT NOT NULL,
    part_id INT,
    device_id INT,
    software_compatibility_level_id INT NOT NULL,
    FOREIGN KEY (software_id) REFERENCES SOFTWARE(id),
    FOREIGN KEY (part_id) REFERENCES PARTS(id),
    FOREIGN KEY (device_id) REFERENCES DEVICES(id),
    FOREIGN KEY (software_compatibility_level_id) REFERENCES SOFTWARE_COMPATIBILITY_LEVELS(id)
);