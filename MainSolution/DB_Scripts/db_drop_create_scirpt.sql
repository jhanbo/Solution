SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

DROP SCHEMA IF EXISTS `itg_wd` ;
CREATE SCHEMA IF NOT EXISTS `itg_wd` DEFAULT CHARACTER SET utf8 ;
USE `itg_wd` ;

-- -----------------------------------------------------
-- Table `itg_wd`.`orgunit`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`orgunit` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`orgunit` (
  `idorgunit` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `itg_user_iditg_user` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `orgunit_idorgunit` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `name` VARCHAR(75) NOT NULL ,
  `code` VARCHAR(15) NULL DEFAULT NULL ,
  `org_type` INT(10) UNSIGNED NOT NULL DEFAULT '0' COMMENT '0 internal, 1 external' ,
  `phone` VARCHAR(45) NULL DEFAULT NULL ,
  `email` VARCHAR(45) NULL DEFAULT NULL ,
  `fax` VARCHAR(45) NULL DEFAULT NULL ,
  `notes` VARCHAR(255) NULL DEFAULT NULL ,
  PRIMARY KEY (`idorgunit`) ,
  INDEX `orgunit_orgunit_fk` (`orgunit_idorgunit` ASC) ,
  INDEX `orgunit_itg_user_fk` (`itg_user_iditg_user` ASC) ,
  CONSTRAINT `orgunit_itg_user_fk`
    FOREIGN KEY (`itg_user_iditg_user` )
    REFERENCES `itg_wd`.`itg_user` (`iditg_user` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `orgunit_orgunit_fk`
    FOREIGN KEY (`orgunit_idorgunit` )
    REFERENCES `itg_wd`.`orgunit` (`idorgunit` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`itg_user`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`itg_user` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`itg_user` (
  `iditg_user` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `orgunit_idorgunit` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `username` VARCHAR(45) NOT NULL ,
  `pass` VARCHAR(255) NULL DEFAULT NULL ,
  `first_name` VARCHAR(45) NOT NULL ,
  `middle_name` VARCHAR(45) NULL DEFAULT NULL ,
  `gf_name` VARCHAR(45) NULL DEFAULT NULL ,
  `last_name` VARCHAR(45) NOT NULL ,
  `phone` VARCHAR(45) NULL DEFAULT NULL ,
  `mobile` VARCHAR(45) NULL DEFAULT NULL ,
  `email` VARCHAR(45) NULL DEFAULT NULL ,
  `birth_date` DATE NULL DEFAULT NULL ,
  `join_date` DATE NULL DEFAULT NULL ,
  `notes` VARCHAR(255) NULL DEFAULT NULL ,
  PRIMARY KEY (`iditg_user`) ,
  INDEX `itg_user_orgunit_fk` (`orgunit_idorgunit` ASC) ,
  CONSTRAINT `itg_user_orgunit_fk`
    FOREIGN KEY (`orgunit_idorgunit` )
    REFERENCES `itg_wd`.`orgunit` (`idorgunit` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`corr_types`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`corr_types` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`corr_types` (
  `idcorr_types` INT(11) NOT NULL AUTO_INCREMENT ,
  `corr_Type_code` VARCHAR(10) NOT NULL ,
  `corr_type_desc` VARCHAR(100) NOT NULL ,
  PRIMARY KEY (`idcorr_types`) )
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`correspondence`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`correspondence` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`correspondence` (
  `idcorrespondence` INT(10) UNSIGNED NOT NULL ,
  `itg_user_iditg_user` INT(10) UNSIGNED NOT NULL ,
  `correspondence_idcorrespondence` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `orgunit_idorgunit` INT(10) UNSIGNED NOT NULL ,
  `record_no` VARCHAR(45) NULL DEFAULT NULL ,
  `devision` VARCHAR(10) NULL DEFAULT NULL ,
  `created_date` DATETIME NULL DEFAULT NULL ,
  `require_followup` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `importance` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `title` VARCHAR(100) NULL DEFAULT NULL ,
  `person_name` VARCHAR(50) NULL DEFAULT NULL ,
  `is_secret` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `is_internal` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `state` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `latest_change_user` VARCHAR(50) NULL DEFAULT NULL ,
  `latest_change_date` DATETIME NULL DEFAULT NULL ,
  `attachments_count` INT(11) NULL DEFAULT '0' ,
  `delivery_meothd` VARCHAR(45) NULL DEFAULT NULL ,
  `record_Date` DATETIME NULL DEFAULT NULL ,
  `corr_type` INT(11) NOT NULL ,
  `is_decision` INT(1) NULL DEFAULT NULL ,
  PRIMARY KEY (`idcorrespondence`) ,
  INDEX `correspondence_orgunit_fk` (`orgunit_idorgunit` ASC) ,
  INDEX `correspondence_correspondence_fk` (`correspondence_idcorrespondence` ASC) ,
  INDEX `correspondence_itg_user_fk` (`itg_user_iditg_user` ASC) ,
  INDEX `correspondence_corr_types_fk` (`corr_type` ASC) ,
  CONSTRAINT `correspondence_correspondence_fk`
    FOREIGN KEY (`correspondence_idcorrespondence` )
    REFERENCES `itg_wd`.`correspondence` (`idcorrespondence` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `correspondence_corr_types_fk`
    FOREIGN KEY (`corr_type` )
    REFERENCES `itg_wd`.`corr_types` (`idcorr_types` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `correspondence_itg_user_fk`
    FOREIGN KEY (`itg_user_iditg_user` )
    REFERENCES `itg_wd`.`itg_user` (`iditg_user` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `correspondence_orgunit_fk`
    FOREIGN KEY (`orgunit_idorgunit` )
    REFERENCES `itg_wd`.`orgunit` (`idorgunit` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`assignment`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`assignment` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`assignment` (
  `idassignment` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `orgunit_idorgunit` INT(10) UNSIGNED NOT NULL ,
  `itg_user_iditg_user` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `correspondence_idcorrespondence` INT(10) UNSIGNED NOT NULL ,
  `assigned_date` DATETIME NULL DEFAULT NULL ,
  `received_date` DATETIME NULL DEFAULT NULL ,
  `due_date` DATETIME NULL DEFAULT NULL ,
  `reminded_date` DATETIME NULL DEFAULT NULL ,
  `actions` VARCHAR(255) NULL DEFAULT NULL ,
  `state` INT(10) UNSIGNED NULL DEFAULT NULL ,
  PRIMARY KEY (`idassignment`) ,
  INDEX `assignment_orgunit_fk` (`orgunit_idorgunit` ASC) ,
  INDEX `assignment_correspondence_fk` (`correspondence_idcorrespondence` ASC) ,
  INDEX `assignment_itg_user_fk` (`itg_user_iditg_user` ASC) ,
  CONSTRAINT `assignment_itg_user_fk`
    FOREIGN KEY (`itg_user_iditg_user` )
    REFERENCES `itg_wd`.`itg_user` (`iditg_user` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `assignment_correspondence_fk`
    FOREIGN KEY (`correspondence_idcorrespondence` )
    REFERENCES `itg_wd`.`correspondence` (`idcorrespondence` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `assignment_orgunit_fk`
    FOREIGN KEY (`orgunit_idorgunit` )
    REFERENCES `itg_wd`.`orgunit` (`idorgunit` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`assignment_attachment`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`assignment_attachment` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`assignment_attachment` (
  `idattachment` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `assignment_idassignment` INT(10) UNSIGNED NOT NULL ,
  `name` VARCHAR(50) NOT NULL ,
  `description` VARCHAR(255) NULL DEFAULT NULL ,
  `created_date` DATETIME NULL DEFAULT NULL ,
  `data_file` BLOB NULL DEFAULT NULL ,
  PRIMARY KEY (`idattachment`) ,
  INDEX `assignment_Attach_assignment_fk` (`assignment_idassignment` ASC) ,
  CONSTRAINT `assignment_Attach_assignment_fk`
    FOREIGN KEY (`assignment_idassignment` )
    REFERENCES `itg_wd`.`assignment` (`idassignment` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`corr_attachment`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`corr_attachment` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`corr_attachment` (
  `idcorr_attachment` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `correspondence_idcorrespondence` INT(10) UNSIGNED NOT NULL ,
  `name` VARCHAR(100) NULL DEFAULT NULL ,
  `created_date` DATETIME NULL DEFAULT NULL ,
  `data_file` MEDIUMBLOB NULL DEFAULT NULL ,
  `description` VARCHAR(500) NULL DEFAULT NULL ,
  PRIMARY KEY (`idcorr_attachment`) ,
  INDEX `corr_attachment_corr_fk` (`correspondence_idcorrespondence` ASC) ,
  CONSTRAINT `corr_attachment_corr_fk`
    FOREIGN KEY (`correspondence_idcorrespondence` )
    REFERENCES `itg_wd`.`correspondence` (`idcorrespondence` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`corr_notes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`corr_notes` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`corr_notes` (
  `idcorr_notes` INT(11) NOT NULL AUTO_INCREMENT ,
  `corr_note` VARCHAR(500) NOT NULL ,
  `note_date` DATETIME NOT NULL ,
  `correspondence_idcorrespondence` INT(10) NOT NULL ,
  `itg_user_iditg_user` INT(10) NOT NULL ,
  PRIMARY KEY (`idcorr_notes`) )
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`corr_trails`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`corr_trails` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`corr_trails` (
  `idcorr_trails` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `itg_user_iditg_user` INT(10) UNSIGNED NOT NULL ,
  `correspondence_idcorrespondence` INT(10) UNSIGNED NOT NULL ,
  `description` VARCHAR(255) NULL DEFAULT NULL ,
  `action_date` DATETIME NULL DEFAULT NULL ,
  PRIMARY KEY (`idcorr_trails`) ,
  INDEX `corr_trails_itg_user_fk` (`itg_user_iditg_user` ASC) ,
  INDEX `corr_trail_corr_fk` (`correspondence_idcorrespondence` ASC) ,
  CONSTRAINT `corr_trails_itg_user_fk`
    FOREIGN KEY (`itg_user_iditg_user` )
    REFERENCES `itg_wd`.`itg_user` (`iditg_user` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `corr_trail_corr_fk`
    FOREIGN KEY (`correspondence_idcorrespondence` )
    REFERENCES `itg_wd`.`correspondence` (`idcorrespondence` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 19
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`correspondence_draft`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`correspondence_draft` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`correspondence_draft` (
  `idcorrespondence_draft` INT(10) UNSIGNED NOT NULL ,
  `itg_user_iditg_user` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `correspondence_idcorrespondence` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `orgunit_idorgunit` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `record_no` VARCHAR(45) NULL DEFAULT NULL ,
  `devision` VARCHAR(10) NULL DEFAULT NULL ,
  `created_date` DATETIME NULL DEFAULT NULL ,
  `require_followup` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `importance` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `title` VARCHAR(100) NULL DEFAULT NULL ,
  `person_name` VARCHAR(50) NULL DEFAULT NULL ,
  `is_secret` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `is_internal` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `latest_change_user` VARCHAR(50) NULL DEFAULT NULL ,
  `latest_change_date` DATETIME NULL DEFAULT NULL ,
  `attachments_count` INT(11) NULL DEFAULT '0' ,
  `delivery_meothd` VARCHAR(45) NULL DEFAULT NULL ,
  `record_Date` DATETIME NULL DEFAULT NULL ,
  `corr_type` INT(11) NULL DEFAULT NULL ,
  `idcorrespondence` INT(11) NULL DEFAULT NULL ,
  `draft_date` DATETIME NULL DEFAULT NULL ,
  PRIMARY KEY (`idcorrespondence_draft`) ,
  INDEX `correspondence_draft_orgunit_fk` (`orgunit_idorgunit` ASC) ,
  INDEX `correspondence_draft_correspondence_fk` (`correspondence_idcorrespondence` ASC) ,
  INDEX `correspondence_draft_itg_user_fk` (`itg_user_iditg_user` ASC) ,
  INDEX `correspondence_draft_corr_types_fk` (`corr_type` ASC) ,
  CONSTRAINT `correspondence_draft_correspondence_fk`
    FOREIGN KEY (`correspondence_idcorrespondence` )
    REFERENCES `itg_wd`.`correspondence` (`idcorrespondence` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `correspondence_draft_corr_types_fk`
    FOREIGN KEY (`corr_type` )
    REFERENCES `itg_wd`.`corr_types` (`idcorr_types` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `correspondence_draft_itg_user_fk`
    FOREIGN KEY (`itg_user_iditg_user` )
    REFERENCES `itg_wd`.`itg_user` (`iditg_user` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `correspondence_draft_orgunit_fk`
    FOREIGN KEY (`orgunit_idorgunit` )
    REFERENCES `itg_wd`.`orgunit` (`idorgunit` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`correspondence_states`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`correspondence_states` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`correspondence_states` (
  `idcorrespondence_states` INT(10) NOT NULL AUTO_INCREMENT ,
  `state_code` VARCHAR(10) NULL DEFAULT NULL ,
  `state_desc` VARCHAR(10) NULL DEFAULT NULL ,
  PRIMARY KEY (`idcorrespondence_states`) ,
  UNIQUE INDEX `idcorrespondence_states_UNIQUE` (`idcorrespondence_states` ASC) )
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`correspondence_to_org`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`correspondence_to_org` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`correspondence_to_org` (
  `correspondence_idcorrespondence` INT(10) UNSIGNED NOT NULL ,
  `orgunit_idorgunit` INT(10) UNSIGNED NOT NULL ,
  `to_cc_type` VARCHAR(2) NOT NULL ,
  `idcorrespondence_to_org` INT(11) NOT NULL AUTO_INCREMENT ,
  PRIMARY KEY (`idcorrespondence_to_org`) ,
  INDEX `corr_to_org_orgunit_fk` (`orgunit_idorgunit` ASC) ,
  INDEX `corr_to_org_corr_fk` (`correspondence_idcorrespondence` ASC) ,
  CONSTRAINT `corr_to_org_corr_fk`
    FOREIGN KEY (`correspondence_idcorrespondence` )
    REFERENCES `itg_wd`.`correspondence` (`idcorrespondence` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `corr_to_org_orgunit_fk`
    FOREIGN KEY (`orgunit_idorgunit` )
    REFERENCES `itg_wd`.`orgunit` (`idorgunit` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 20
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`org_setting`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`org_setting` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`org_setting` (
  `idorg_setting` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `orgunit_idorgunit` INT(10) UNSIGNED NOT NULL ,
  `name` VARCHAR(100) NOT NULL ,
  `value` VARCHAR(255) NULL DEFAULT NULL ,
  PRIMARY KEY (`idorg_setting`) ,
  INDEX `org_settings_orgunit_fk` (`orgunit_idorgunit` ASC) ,
  CONSTRAINT `org_settings_orgunit_fk`
    FOREIGN KEY (`orgunit_idorgunit` )
    REFERENCES `itg_wd`.`orgunit` (`idorgunit` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`role`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`role` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`role` (
  `idrole` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `description` VARCHAR(255) NULL DEFAULT NULL ,
  PRIMARY KEY (`idrole`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`permission`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`permission` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`permission` (
  `idpermission` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `role_idrole` INT(10) UNSIGNED NULL DEFAULT NULL ,
  `name` VARCHAR(50) NOT NULL ,
  `code` VARCHAR(20) NOT NULL ,
  `description` VARCHAR(255) NULL DEFAULT NULL ,
  PRIMARY KEY (`idpermission`) ,
  INDEX `permission_role_fk` (`role_idrole` ASC) ,
  CONSTRAINT `permission_role_fk`
    FOREIGN KEY (`role_idrole` )
    REFERENCES `itg_wd`.`role` (`idrole` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`system_setting`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`system_setting` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`system_setting` (
  `idsystem_setting` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(100) NOT NULL ,
  `value` VARCHAR(255) NULL DEFAULT NULL ,
  PRIMARY KEY (`idsystem_setting`) )
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `itg_wd`.`user_role_org`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `itg_wd`.`user_role_org` ;

CREATE  TABLE IF NOT EXISTS `itg_wd`.`user_role_org` (
  `itg_user_iditg_user` INT(10) UNSIGNED NOT NULL ,
  `orgunit_idorgunit` INT(10) UNSIGNED NOT NULL ,
  `role_idrole` INT(10) UNSIGNED NOT NULL ,
  INDEX `user_role_org_role_fk` (`role_idrole` ASC) ,
  INDEX `user_role_org_user_fk` (`itg_user_iditg_user` ASC) ,
  INDEX `user_role_org_orgunit_fk` (`orgunit_idorgunit` ASC) ,
  CONSTRAINT `user_role_org_orgunit_fk`
    FOREIGN KEY (`orgunit_idorgunit` )
    REFERENCES `itg_wd`.`orgunit` (`idorgunit` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `user_role_org_role_fk`
    FOREIGN KEY (`role_idrole` )
    REFERENCES `itg_wd`.`role` (`idrole` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `user_role_org_user_fk`
    FOREIGN KEY (`itg_user_iditg_user` )
    REFERENCES `itg_wd`.`itg_user` (`iditg_user` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
