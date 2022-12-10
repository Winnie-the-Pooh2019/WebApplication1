drop table if exists categories cascade;
drop table if exists price_change cascade;
drop table if exists publisher cascade;
drop table if exists clients cascade;
drop table if exists store cascade;
drop table if exists deliveries cascade;
drop table if exists books cascade;
drop table if exists purchases cascade;
drop table if exists purchase_item cascade;

begin;
\i '/home/ivan/RiderProjects/samples/WebApplication1/res/sql/create.sql';

\copy categories from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/categories.csv' with csv header delimiter ';';
\copy books from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/books.csv' with csv header delimiter ';';
\copy clients from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/clients.csv' with csv header delimiter ';';
\copy deliveries from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/deliveries.csv' with csv header delimiter ';';
\copy price_change from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/price_change.csv' with csv header delimiter ';';
\copy publisher from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/publisher.csv' with csv header delimiter ';';
\copy purchase_item from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/purchase_item.csv' with csv header delimiter ';';
\copy purchases from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/purchases.csv' with csv header delimiter ';';
\copy store from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/store.csv' with csv header delimiter ';';

\i '/home/ivan/RiderProjects/samples/WebApplication1/res/sql/constraints.sql';
commit;

