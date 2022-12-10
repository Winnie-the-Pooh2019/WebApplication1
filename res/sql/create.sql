create table categories
(
    id   int primary key,
    name varchar
);

create table price_change
(
    id            int primary key,
    price_changed date,
    new_price     double precision
);

create table publisher
(
    id   int primary key,
    name varchar
);

create table clients
(
    id         int primary key,
    last_name  varchar,
    first_name varchar
);

create table store
(
    book_id       int primary key,
    books_count   int,
    current_price int
);

create table deliveries
(
    id            int primary key,
    book_id       int,
    delivery_date date,
    books_count   int,
    price         double precision
);

create table books
(
    id           int primary key,
    name         varchar,
    publisher_id int,
    category_id  int
);

create table purchases
(
    id            int primary key,
    customer_id   int,
    purchase_date date
);

create table purchase_item
(
    id            int primary key,
    purchase_id   int,
    book_id       int,
    books_count   int,
    current_price int
);