alter table purchases
    add constraint fk_purchases_clients
        foreign key (customer_id) references clients (id) on delete cascade;

alter table "purchaseItems"
    add constraint fk_purchase_item_purchase
        foreign key (purchase_id) references purchases (id) on delete cascade;

alter table "purchaseItems"
    add constraint fk_purchase_item_books
        foreign key (book_id) references books (id) on delete cascade;

alter table "purchaseItems"
    add constraint fk_purchase_item_price_change
        foreign key (current_price) references price_change (id) on delete cascade;

alter table books
    add constraint fk_books_publisher
        foreign key (publisher_id) references publisher (id) on delete cascade;

alter table books
    add constraint fk_books_categories
        foreign key (category_id) references categories (id) on delete cascade;

alter table deliveries
    add constraint fk_deliveries_books
        foreign key (book_id) references books (id) on delete cascade;

alter table store
    add constraint fk_store_books
        foreign key (book_id) references books (id) on delete cascade;

alter table store
    add constraint fk_store_price_change
        foreign key (current_price) references price_change (id) on delete cascade;