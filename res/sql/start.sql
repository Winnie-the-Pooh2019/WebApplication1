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
\i '/home/ivan/RiderProjects/WebApplication1/res/sql/create.sql';

\copy categories from '';

\i '/home/ivan/RiderProjects/WebApplication1/res/sql/constraints.sql';
commit;

