namespace ListaDeTarefas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tarefas3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarefas", "Completo", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tarefas", "Completas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarefas", "Completas", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tarefas", "Completo");
        }
    }
}
