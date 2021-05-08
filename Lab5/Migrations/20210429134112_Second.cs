using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab5.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_EvaluationCriteria_EvaluationCriteriaId",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_RealEstateObject_RealEstateObjectId",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateObject_BuildingMaterial_BuldingMaterialId",
                table: "RealEstateObject");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateObject_District_DistrictId",
                table: "RealEstateObject");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateObject_RealEstateType_RealEstateTypeId",
                table: "RealEstateObject");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_RealEstateObject_RealEstateObjectId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Realtor_RealtorId",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Realtor",
                table: "Realtor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstateType",
                table: "RealEstateType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstateObject",
                table: "RealEstateObject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvaluationCriteria",
                table: "EvaluationCriteria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluation",
                table: "Evaluation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingMaterial",
                table: "BuildingMaterial");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Sales");

            migrationBuilder.RenameTable(
                name: "Realtor",
                newName: "Realtors");

            migrationBuilder.RenameTable(
                name: "RealEstateType",
                newName: "RealEstateTypes");

            migrationBuilder.RenameTable(
                name: "RealEstateObject",
                newName: "RealEstateObjects");

            migrationBuilder.RenameTable(
                name: "EvaluationCriteria",
                newName: "EvaluationCriterias");

            migrationBuilder.RenameTable(
                name: "Evaluation",
                newName: "Evaluations");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "Districts");

            migrationBuilder.RenameTable(
                name: "BuildingMaterial",
                newName: "BuildingMaterials");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_RealtorId",
                table: "Sales",
                newName: "IX_Sales_RealtorId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_RealEstateObjectId",
                table: "Sales",
                newName: "IX_Sales_RealEstateObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstateObject_RealEstateTypeId",
                table: "RealEstateObjects",
                newName: "IX_RealEstateObjects_RealEstateTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstateObject_DistrictId",
                table: "RealEstateObjects",
                newName: "IX_RealEstateObjects_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstateObject_BuldingMaterialId",
                table: "RealEstateObjects",
                newName: "IX_RealEstateObjects_BuldingMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluation_RealEstateObjectId",
                table: "Evaluations",
                newName: "IX_Evaluations_RealEstateObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluation_EvaluationCriteriaId",
                table: "Evaluations",
                newName: "IX_Evaluations_EvaluationCriteriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Realtors",
                table: "Realtors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstateTypes",
                table: "RealEstateTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstateObjects",
                table: "RealEstateObjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvaluationCriterias",
                table: "EvaluationCriterias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluations",
                table: "Evaluations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingMaterials",
                table: "BuildingMaterials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_EvaluationCriterias_EvaluationCriteriaId",
                table: "Evaluations",
                column: "EvaluationCriteriaId",
                principalTable: "EvaluationCriterias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_RealEstateObjects_RealEstateObjectId",
                table: "Evaluations",
                column: "RealEstateObjectId",
                principalTable: "RealEstateObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateObjects_BuildingMaterials_BuldingMaterialId",
                table: "RealEstateObjects",
                column: "BuldingMaterialId",
                principalTable: "BuildingMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateObjects_Districts_DistrictId",
                table: "RealEstateObjects",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateObjects_RealEstateTypes_RealEstateTypeId",
                table: "RealEstateObjects",
                column: "RealEstateTypeId",
                principalTable: "RealEstateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_RealEstateObjects_RealEstateObjectId",
                table: "Sales",
                column: "RealEstateObjectId",
                principalTable: "RealEstateObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Realtors_RealtorId",
                table: "Sales",
                column: "RealtorId",
                principalTable: "Realtors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_EvaluationCriterias_EvaluationCriteriaId",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_RealEstateObjects_RealEstateObjectId",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateObjects_BuildingMaterials_BuldingMaterialId",
                table: "RealEstateObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateObjects_Districts_DistrictId",
                table: "RealEstateObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateObjects_RealEstateTypes_RealEstateTypeId",
                table: "RealEstateObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_RealEstateObjects_RealEstateObjectId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Realtors_RealtorId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Realtors",
                table: "Realtors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstateTypes",
                table: "RealEstateTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstateObjects",
                table: "RealEstateObjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluations",
                table: "Evaluations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvaluationCriterias",
                table: "EvaluationCriterias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingMaterials",
                table: "BuildingMaterials");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "Sale");

            migrationBuilder.RenameTable(
                name: "Realtors",
                newName: "Realtor");

            migrationBuilder.RenameTable(
                name: "RealEstateTypes",
                newName: "RealEstateType");

            migrationBuilder.RenameTable(
                name: "RealEstateObjects",
                newName: "RealEstateObject");

            migrationBuilder.RenameTable(
                name: "Evaluations",
                newName: "Evaluation");

            migrationBuilder.RenameTable(
                name: "EvaluationCriterias",
                newName: "EvaluationCriteria");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "District");

            migrationBuilder.RenameTable(
                name: "BuildingMaterials",
                newName: "BuildingMaterial");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_RealtorId",
                table: "Sale",
                newName: "IX_Sale_RealtorId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_RealEstateObjectId",
                table: "Sale",
                newName: "IX_Sale_RealEstateObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstateObjects_RealEstateTypeId",
                table: "RealEstateObject",
                newName: "IX_RealEstateObject_RealEstateTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstateObjects_DistrictId",
                table: "RealEstateObject",
                newName: "IX_RealEstateObject_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstateObjects_BuldingMaterialId",
                table: "RealEstateObject",
                newName: "IX_RealEstateObject_BuldingMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_RealEstateObjectId",
                table: "Evaluation",
                newName: "IX_Evaluation_RealEstateObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_EvaluationCriteriaId",
                table: "Evaluation",
                newName: "IX_Evaluation_EvaluationCriteriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Realtor",
                table: "Realtor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstateType",
                table: "RealEstateType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstateObject",
                table: "RealEstateObject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluation",
                table: "Evaluation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvaluationCriteria",
                table: "EvaluationCriteria",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingMaterial",
                table: "BuildingMaterial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_EvaluationCriteria_EvaluationCriteriaId",
                table: "Evaluation",
                column: "EvaluationCriteriaId",
                principalTable: "EvaluationCriteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_RealEstateObject_RealEstateObjectId",
                table: "Evaluation",
                column: "RealEstateObjectId",
                principalTable: "RealEstateObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateObject_BuildingMaterial_BuldingMaterialId",
                table: "RealEstateObject",
                column: "BuldingMaterialId",
                principalTable: "BuildingMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateObject_District_DistrictId",
                table: "RealEstateObject",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateObject_RealEstateType_RealEstateTypeId",
                table: "RealEstateObject",
                column: "RealEstateTypeId",
                principalTable: "RealEstateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_RealEstateObject_RealEstateObjectId",
                table: "Sale",
                column: "RealEstateObjectId",
                principalTable: "RealEstateObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Realtor_RealtorId",
                table: "Sale",
                column: "RealtorId",
                principalTable: "Realtor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
