CREATE TABLE "Funcionarios" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Funcionarios" PRIMARY KEY AUTOINCREMENT,
    "Nome" TEXT NOT NULL,
    "CPF" TEXT NOT NULL,
    "Situacao" text NOT NULL,
    "DataModificacao" TEXT NOT NULL
);


CREATE TABLE "Tickets" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Tickets" PRIMARY KEY AUTOINCREMENT,
    "Quantidade" INTEGER NOT NULL,
    "Situacao" TEXT NOT NULL,
    "DataModificacao" TEXT NOT NULL,
    "DataCriacao" TEXT NOT NULL,
    "FuncionarioId" INTEGER NOT NULL,
    CONSTRAINT "FK_Tickets_Funcionarios_FuncionarioId" FOREIGN KEY ("FuncionarioId") REFERENCES "Funcionarios" ("Id") ON DELETE RESTRICT
);


CREATE UNIQUE INDEX "IX_Funcionarios_CPF" ON "Funcionarios" ("CPF");


CREATE INDEX "IX_Tickets_FuncionarioId" ON "Tickets" ("FuncionarioId");


