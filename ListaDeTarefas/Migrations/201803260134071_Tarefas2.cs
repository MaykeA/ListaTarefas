namespace ListaDeTarefas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tarefas2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarefas", "Descrição", c => c.String());
            AddColumn("dbo.Tarefas", "Completo", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tarefas", "Descricao");
            DropColumn("dbo.Tarefas", "Completa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarefas", "Completa", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tarefas", "Descricao", c => c.String());
            DropColumn("dbo.Tarefas", "Completo");
            DropColumn("dbo.Tarefas", "Descrição");
        }
    }
}
