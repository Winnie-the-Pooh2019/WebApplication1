begin;

\copy categories from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/categories.csv' with csv header delimiter ';';
\copy publishers from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/publisher.csv' with csv header delimiter ';';
\copy clients from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/clients.csv' with csv header delimiter ';';
\copy books from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/books.csv' with csv header delimiter ';';
\copy purchases from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/purchases.csv' with csv header delimiter ';';
\copy "priceChanges" from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/price_change.csv' with csv header delimiter ';';
\copy "purchaseItems" from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/purchase_item.csv' with csv header delimiter ';';
\copy deliveries from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/deliveries.csv' with csv header delimiter ';';
\copy stores from '/home/ivan/RiderProjects/samples/WebApplication1/res/data/store.csv' with csv header delimiter ';';

end;