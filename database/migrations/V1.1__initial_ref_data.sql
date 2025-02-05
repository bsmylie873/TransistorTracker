INSERT INTO HARDWARE_STATUSES (id, name) VALUES
(1, 'Active'),
(2, 'Inactive');

ALTER SEQUENCE hardware_statuses_id_seq RESTART WITH 3;

INSERT INTO HARDWARE_CONDITIONS (id, name) VALUES
(1, 'Working'),
(2, 'Partially Working'),
(3, 'Defective');

ALTER SEQUENCE hardware_conditions_id_seq RESTART WITH 4;

INSERT INTO USER_TYPES (id, name) VALUES
(1, 'User'),
(2, 'Moderator'),
(3, 'Admin');

ALTER SEQUENCE user_types_id_seq RESTART WITH 4;