
-- 新增資料表
create table Pokemon 
(   PokeID int identity(1,1) primary key , 
    PokeName varchar(100), 
    PokeImage varchar(100), 
    Memo varchar(100) , 
    PokeDate datetime default sysdatetime() )
go


-- 新增資料
insert into Pokemon (PokeName, PokeImage) values ('妙蛙種子', '/images/pokemon/001.png');
insert into Pokemon (PokeName, PokeImage) values ('妙蛙草', '/images/pokemon/002.png');
insert into Pokemon (PokeName, PokeImage) values ('妙蛙花', '/images/pokemon/003.png');
insert into Pokemon (PokeName, PokeImage) values ('小火龍', '/images/pokemon/004.png');
insert into Pokemon (PokeName, PokeImage) values ('火恐龍', '/images/pokemon/005.png');
insert into Pokemon (PokeName, PokeImage) values ('噴火龍', '/images/pokemon/006.png');
insert into Pokemon (PokeName, PokeImage) values ('傑尼龜', '/images/pokemon/007.png');
insert into Pokemon (PokeName, PokeImage) values ('卡咪龜', '/images/pokemon/008.png');
insert into Pokemon (PokeName, PokeImage) values ('水箭龜', '/images/pokemon/009.png');
insert into Pokemon (PokeName, PokeImage) values ('綠毛蟲', '/images/pokemon/010.png');
insert into Pokemon (PokeName, PokeImage) values ('鐵甲蛹', '/images/pokemon/011.png');
insert into Pokemon (PokeName, PokeImage) values ('巴大蝶', '/images/pokemon/012.png');
insert into Pokemon (PokeName, PokeImage) values ('獨角蟲', '/images/pokemon/013.png');
insert into Pokemon (PokeName, PokeImage) values ('鐵殼蛹', '/images/pokemon/014.png');
insert into Pokemon (PokeName, PokeImage) values ('大針蜂', '/images/pokemon/015.png');
insert into Pokemon (PokeName, PokeImage) values ('波波', '/images/pokemon/016.png');
insert into Pokemon (PokeName, PokeImage) values ('比比鳥', '/images/pokemon/017.png');
insert into Pokemon (PokeName, PokeImage) values ('大比鳥', '/images/pokemon/018.png');
insert into Pokemon (PokeName, PokeImage) values ('小拉達', '/images/pokemon/019.png');
insert into Pokemon (PokeName, PokeImage) values ('拉達', '/images/pokemon/020.png');
insert into Pokemon (PokeName, PokeImage) values ('烈雀', '/images/pokemon/021.png');
insert into Pokemon (PokeName, PokeImage) values ('大嘴雀', '/images/pokemon/022.png');
insert into Pokemon (PokeName, PokeImage) values ('阿柏蛇', '/images/pokemon/023.png');
insert into Pokemon (PokeName, PokeImage) values ('阿柏怪', '/images/pokemon/024.png');
insert into Pokemon (PokeName, PokeImage) values ('皮卡丘', '/images/pokemon/025.png');
go


create table PokemonSkill(
   SkillID int identity(1,1) primary key,
   PokeID int foreign key references Pokemon(PokeID),
   PokeSkill varchar(100)
)
go

insert into PokemonSkill (PokeID, PokeSkill) values (1,'藤鞭');
insert into PokemonSkill (PokeID, PokeSkill) values (1,'撞擊');
insert into PokemonSkill (PokeID, PokeSkill) values (1,'種子炸彈');
insert into PokemonSkill (PokeID, PokeSkill) values (1,'強力鞭打');
insert into PokemonSkill (PokeID, PokeSkill) values (2,'藤鞭');
insert into PokemonSkill (PokeID, PokeSkill) values (2,'飛葉快刀');
go
