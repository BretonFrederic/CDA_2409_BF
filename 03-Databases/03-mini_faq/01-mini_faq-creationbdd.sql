
DROP DATABASE IF EXISTS mini_faq;

CREATE DATABASE mini_faq;

USE mini_faq;

CREATE TABLE users
(
	user_id INT PRIMARY KEY AUTO_INCREMENT,
    user_email VARCHAR(128) UNIQUE NOT NULL,
    user_lastname VARCHAR(50) NOT NULL,
    user_firstname VARCHAR(50) NOT NULL
);

CREATE TABLE questions
(
	question_id INT PRIMARY KEY AUTO_INCREMENT,
    question_date DATE NOT NULL,
    question_label VARCHAR(255) NOT NULL,
    question_response TEXT(65535) NOT NULL,
    user_id INT
);

CREATE TABLE categories
(
	category_name VARCHAR(30) PRIMARY KEY ,
    category_description VARCHAR(255),
    category_order INT(3) NOT NULL UNIQUE
);

CREATE TABLE categories_questions
(
	question_id INT,
    category_name VARCHAR(30),
    PRIMARY KEY(question_id, category_name)
);

ALTER TABLE questions ADD FOREIGN KEY (user_id) REFERENCES users(user_id);

ALTER TABLE categories_questions
ADD CONSTRAINT fk_categories_questions_questions FOREIGN KEY (question_id) REFERENCES questions(question_id),
ADD CONSTRAINT fk_categories_questions_categories FOREIGN KEY (category_name) REFERENCES categories(category_name);
