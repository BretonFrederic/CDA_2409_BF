USE mini_faq;
/* 1. Sélectionner tous les utilisateurs (identifiant, nom, prénom, email). */
SELECT user_id, user_lastname, user_firstname, user_email
FROM users;

/* 2. Sélectionner toutes les questions (date, intitulé, réponse, identifiant utilisateur) triées par date de la plus ancienne à la plus récente. */
SELECT question_id, date_format(question_date, "%Y/%m/%d"), question_label, question_response, user_id
FROM questions
ORDER BY question_date ASC;

/* 3. Sélectionner les questions (identifiant, date, intitulé, réponse) de l’utilisateur n°2. */
SELECT question_id, date_format(question_date, "%Y/%m/%d"), question_label, question_response
FROM questions
WHERE user_id = 2;

/* 4. Sélectionner les questions (date, intitulé, réponse, identifiant utilisateur) de l’utilisateur Eva Satiti. */
SELECT date_format(question_date, "%Y/%m/%d"), question_label, question_response, user_id
FROM questions
WHERE user_id = 3;

/* 5. Sélectionner les questions (identifiant, date, intitulé, réponse, identifiant utilisateur) dont l’intitulé contient “SQL”. Le résultat est trié par le titre et par ordre décroissant. */
SELECT question_id, date_format(question_date, "%Y/%m/%d"), question_label, question_response, user_id
FROM questions
WHERE question_label LIKE "%SQL%" ORDER BY question_label;

/* 6. Sélectionner les catégories (nom, description) sans question associée. */
SELECT category_name, category_description
FROM categories;

/* 7. Sélectionner les questions triées par titre (ordre alphabétique) avec le nom et prénom de l’auteur (nécessite une jointure). */
SELECT question_label, user_lastname, user_firstname
FROM questions
INNER JOIN users ON questions.question_id = users.user_id ORDER BY question_label ASC;


/* 8. Sélectionner les catégories (nom) avec, pour chaque catégorie le nombre de questions associées (nécessite une jointure). */
SELECT categories.category_name, SUM(question_id)
FROM categories
INNER JOIN categories_questions ON categories.category_name = categories_questions.id;
