create table categories
(
    id   int primary key,
    name varchar
);

create table "priceChanges"
(
    id            int primary key,
    priceChanged date,
    newPrice     double precision
);

create table publishers
(
    id   int primary key,
    name varchar
);

create table clients
(
    id         int primary key,
    lastName  varchar,
    firstName varchar
);

create table stores
(
    bookId       int primary key,
    booksCount   int,
    priceId int
);

create table deliveries
(
    id            int primary key,
    bookId       int,
    deliveryDate date,
    booksCount   int,
    price         double precision
);

create table books
(
    id           int primary key,
    name         varchar,
    publisherId int,
    categoryId  int
);

create table purchases
(
    id            int primary key,
    customerId   int,
    purchaseDate date
);

create table "purchaseItems"
(
    id            int primary key,
    purchaseId   int,
    bookId       int,
    booksCount   int,
    priceId int
);