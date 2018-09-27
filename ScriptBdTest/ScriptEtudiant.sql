create database etudiant_test
go

use etudiant_test
go

create table tmp_query
(
	id integer,
	requete varchar(250),
	constraint pk_tmp_query primary key(id),
	constraint uk_tmp_query unique(requete)
)

create table radcheck
(
	id integer identity,
	username varchar(64) not null,
	attribute varchar(64) not null,
	op varchar(2) not null,
	value varchar(253) not null,
	constraint pk_radckeck primary key(id)
)

select * from tmp_query
select * from radcheck
--truncate table tmp_query
--truncate table radcheck
--delete from tmp_query

insert into tmp_query(id,requete) values(1,'insert into radcheck(username,attribute,op,value)
 values(''15IGGJ2569'',''Cleartext-Password'','':='',''AfG5'')');
insert into tmp_query(id,requete) values(2,'insert into radcheck(username,attribute,op,value) 
values(''10IJ18184'',''Cleartext-Password'','':='',''yaNN'')');
insert into tmp_query(id,requete) values(3,'insert into radcheck(username,attribute,op,value) 
values(''07DJ15024'',''Cleartext-Password'','':='',''taiY'')');
insert into tmp_query(id,requete) values(4,'insert into radcheck(username,attribute,op,value) 
values(''07DJ15076'',''Cleartext-Password'','':='',''mI5n'')');
insert into tmp_query(id,requete) values(5,'insert into radcheck(username,attribute,op,value) 
values(''07IJ15065'',''Cleartext-Password'','':='',''+Zks'')');
insert into tmp_query(id,requete) values(6,'insert into radcheck(username,attribute,op,value) 
values(''08DJ16013'',''Cleartext-Password'','':='',''4t0p'')');
insert into tmp_query(id,requete) values(7,'insert into radcheck(username,attribute,op,value) 
values(''08DJ16018'',''Cleartext-Password'','':='',''9hqa'')');
insert into tmp_query(id,requete) values(8,'insert into radcheck(username,attribute,op,value) 
values(''08DJ16064'',''Cleartext-Password'','':='',''oGAq'')');
insert into tmp_query(id,requete) values(9,'insert into radcheck(username,attribute,op,value) 
values(''08DS16028'',''Cleartext-Password'','':='',''FLbw'')');
insert into tmp_query(id,requete) values(10,'insert into radcheck(username,attribute,op,value) 
values(''08IJ16020'',''Cleartext-Password'','':='',''dE42'')');