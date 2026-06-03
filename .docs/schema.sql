CREATE TABLE public.alunos (
    id integer NOT NULL,
    id_curso integer NOT NULL,
    nome character varying(100) NOT NULL,
    cpf character varying(14) NOT NULL,
    email character varying(100) NOT NULL,
    data_nascimento date NOT NULL,
    status_aluno character varying(20) DEFAULT 'Ativo'::character varying
);


ALTER TABLE public.alunos OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 92640)
-- Name: alunos_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.alunos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.alunos_id_seq OWNER TO postgres;

--
-- TOC entry 3425 (class 0 OID 0)
-- Dependencies: 223
-- Name: alunos_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.alunos_id_seq OWNED BY public.alunos.id;


--
-- TOC entry 220 (class 1259 OID 92610)
-- Name: cursos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cursos (
    id integer NOT NULL,
    id_coordenador integer NOT NULL,
    nome character varying(100) NOT NULL,
    sigla character varying(10) NOT NULL,
    carga_horaria_total integer NOT NULL
);


ALTER TABLE public.cursos OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 92609)
-- Name: cursos_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.cursos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.cursos_id_seq OWNER TO postgres;

--
-- TOC entry 3428 (class 0 OID 0)
-- Dependencies: 219
-- Name: cursos_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.cursos_id_seq OWNED BY public.cursos.id;


--
-- TOC entry 222 (class 1259 OID 92624)
-- Name: disciplinas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.disciplinas (
    id integer NOT NULL,
    id_curso integer NOT NULL,
    id_professor integer NOT NULL,
    nome character varying(100) NOT NULL,
    carga_horaria integer NOT NULL,
    semestre_oferta integer NOT NULL
);


ALTER TABLE public.disciplinas OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 92623)
-- Name: disciplinas_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.disciplinas_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.disciplinas_id_seq OWNER TO postgres;

--
-- TOC entry 3431 (class 0 OID 0)
-- Dependencies: 221
-- Name: disciplinas_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.disciplinas_id_seq OWNED BY public.disciplinas.id;


--
-- TOC entry 226 (class 1259 OID 92658)
-- Name: matriculas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.matriculas (
    id integer NOT NULL,
    id_disciplina integer NOT NULL,
    id_aluno integer NOT NULL,
    data_matricula timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    nota_final numeric(5,2),
    status_matricula character varying(20) DEFAULT 'Cursando'::character varying
);


ALTER TABLE public.matriculas OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 92657)
-- Name: matriculas_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.matriculas_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.matriculas_id_seq OWNER TO postgres;

--
-- TOC entry 3434 (class 0 OID 0)
-- Dependencies: 225
-- Name: matriculas_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.matriculas_id_seq OWNED BY public.matriculas.id;


--
-- TOC entry 218 (class 1259 OID 92600)
-- Name: professores; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.professores (
    id integer NOT NULL,
    nome character varying(100) NOT NULL,
    email character varying(100) NOT NULL,
    titulacao character varying(50) NOT NULL,
    data_contratacao date DEFAULT CURRENT_DATE
);


ALTER TABLE public.professores OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 92599)
-- Name: professores_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.professores_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.professores_id_seq OWNER TO postgres;

--
-- TOC entry 3437 (class 0 OID 0)
-- Dependencies: 217
-- Name: professores_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.professores_id_seq OWNED BY public.professores.id;


--
-- TOC entry 3236 (class 2604 OID 92644)
-- Name: alunos id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alunos ALTER COLUMN id SET DEFAULT nextval('public.alunos_id_seq'::regclass);


--
-- TOC entry 3234 (class 2604 OID 92613)
-- Name: cursos id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cursos ALTER COLUMN id SET DEFAULT nextval('public.cursos_id_seq'::regclass);


--
-- TOC entry 3235 (class 2604 OID 92627)
-- Name: disciplinas id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.disciplinas ALTER COLUMN id SET DEFAULT nextval('public.disciplinas_id_seq'::regclass);


--
-- TOC entry 3238 (class 2604 OID 92661)
-- Name: matriculas id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matriculas ALTER COLUMN id SET DEFAULT nextval('public.matriculas_id_seq'::regclass);


--
-- TOC entry 3232 (class 2604 OID 92603)
-- Name: professores id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professores ALTER COLUMN id SET DEFAULT nextval('public.professores_id_seq'::regclass);


--
-- TOC entry 3255 (class 2606 OID 92649)
-- Name: alunos alunos_cpf_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alunos
    ADD CONSTRAINT alunos_cpf_key UNIQUE (cpf);


--
-- TOC entry 3257 (class 2606 OID 92651)
-- Name: alunos alunos_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alunos
    ADD CONSTRAINT alunos_email_key UNIQUE (email);


--
-- TOC entry 3259 (class 2606 OID 92647)
-- Name: alunos alunos_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alunos
    ADD CONSTRAINT alunos_pkey PRIMARY KEY (id);


--
-- TOC entry 3246 (class 2606 OID 92615)
-- Name: cursos cursos_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cursos
    ADD CONSTRAINT cursos_pkey PRIMARY KEY (id);


--
-- TOC entry 3248 (class 2606 OID 92617)
-- Name: cursos cursos_sigla_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cursos
    ADD CONSTRAINT cursos_sigla_key UNIQUE (sigla);


--
-- TOC entry 3251 (class 2606 OID 92629)
-- Name: disciplinas disciplinas_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.disciplinas
    ADD CONSTRAINT disciplinas_pkey PRIMARY KEY (id);


--
-- TOC entry 3264 (class 2606 OID 92665)
-- Name: matriculas matriculas_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matriculas
    ADD CONSTRAINT matriculas_pkey PRIMARY KEY (id);


--
-- TOC entry 3242 (class 2606 OID 92608)
-- Name: professores professores_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professores
    ADD CONSTRAINT professores_email_key UNIQUE (email);


--
-- TOC entry 3244 (class 2606 OID 92606)
-- Name: professores professores_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professores
    ADD CONSTRAINT professores_pkey PRIMARY KEY (id);


--
-- TOC entry 3266 (class 2606 OID 92667)
-- Name: matriculas uk_aluno_disciplina; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matriculas
    ADD CONSTRAINT uk_aluno_disciplina UNIQUE (id_aluno, id_disciplina);


--
-- TOC entry 3260 (class 1259 OID 92681)
-- Name: idx_alunos_curso; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_alunos_curso ON public.alunos USING btree (id_curso);


--
-- TOC entry 3249 (class 1259 OID 92678)
-- Name: idx_cursos_coordenador; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_cursos_coordenador ON public.cursos USING btree (id_coordenador);


--
-- TOC entry 3252 (class 1259 OID 92679)
-- Name: idx_disciplinas_curso; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_disciplinas_curso ON public.disciplinas USING btree (id_curso);


--
-- TOC entry 3253 (class 1259 OID 92680)
-- Name: idx_disciplinas_professor; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_disciplinas_professor ON public.disciplinas USING btree (id_professor);


--
-- TOC entry 3261 (class 1259 OID 92682)
-- Name: idx_matriculas_aluno; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_matriculas_aluno ON public.matriculas USING btree (id_aluno);


--
-- TOC entry 3262 (class 1259 OID 92683)
-- Name: idx_matriculas_disciplina; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_matriculas_disciplina ON public.matriculas USING btree (id_disciplina);


--
-- TOC entry 3270 (class 2606 OID 92652)
-- Name: alunos fk_alunos_curso; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alunos
    ADD CONSTRAINT fk_alunos_curso FOREIGN KEY (id_curso) REFERENCES public.cursos(id);


--
-- TOC entry 3267 (class 2606 OID 92618)
-- Name: cursos fk_cursos_coordenador; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cursos
    ADD CONSTRAINT fk_cursos_coordenador FOREIGN KEY (id_coordenador) REFERENCES public.professores(id);


--
-- TOC entry 3268 (class 2606 OID 92630)
-- Name: disciplinas fk_disciplinas_curso; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.disciplinas
    ADD CONSTRAINT fk_disciplinas_curso FOREIGN KEY (id_curso) REFERENCES public.cursos(id);


--
-- TOC entry 3269 (class 2606 OID 92635)
-- Name: disciplinas fk_disciplinas_professor; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.disciplinas
    ADD CONSTRAINT fk_disciplinas_professor FOREIGN KEY (id_professor) REFERENCES public.professores(id);


--
-- TOC entry 3271 (class 2606 OID 92673)
-- Name: matriculas fk_matriculas_aluno; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matriculas
    ADD CONSTRAINT fk_matriculas_aluno FOREIGN KEY (id_aluno) REFERENCES public.alunos(id);


--
-- TOC entry 3272 (class 2606 OID 92668)
-- Name: matriculas fk_matriculas_disciplina; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matriculas
    ADD CONSTRAINT fk_matriculas_disciplina FOREIGN KEY (id_disciplina) REFERENCES public.disciplinas(id);


--
-- TOC entry 3423 (class 0 OID 0)
-- Dependencies: 5
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: pg_database_owner
--

GRANT ALL ON SCHEMA public TO poo_user;


--
-- TOC entry 3424 (class 0 OID 0)
-- Dependencies: 224
-- Name: TABLE alunos; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.alunos TO poo_user;


--
-- TOC entry 3426 (class 0 OID 0)
-- Dependencies: 223
-- Name: SEQUENCE alunos_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.alunos_id_seq TO poo_user;


--
-- TOC entry 3427 (class 0 OID 0)
-- Dependencies: 220
-- Name: TABLE cursos; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.cursos TO poo_user;


--
-- TOC entry 3429 (class 0 OID 0)
-- Dependencies: 219
-- Name: SEQUENCE cursos_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.cursos_id_seq TO poo_user;


--
-- TOC entry 3430 (class 0 OID 0)
-- Dependencies: 222
-- Name: TABLE disciplinas; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.disciplinas TO poo_user;


--
-- TOC entry 3432 (class 0 OID 0)
-- Dependencies: 221
-- Name: SEQUENCE disciplinas_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.disciplinas_id_seq TO poo_user;


--
-- TOC entry 3433 (class 0 OID 0)
-- Dependencies: 226
-- Name: TABLE matriculas; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.matriculas TO poo_user;


--
-- TOC entry 3435 (class 0 OID 0)
-- Dependencies: 225
-- Name: SEQUENCE matriculas_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.matriculas_id_seq TO poo_user;


--
-- TOC entry 3436 (class 0 OID 0)
-- Dependencies: 218
-- Name: TABLE professores; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.professores TO poo_user;


--
-- TOC entry 3438 (class 0 OID 0)
-- Dependencies: 217
-- Name: SEQUENCE professores_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.professores_id_seq TO poo_user;


--
-- TOC entry 2065 (class 826 OID 92687)
-- Name: DEFAULT PRIVILEGES FOR SEQUENCES; Type: DEFAULT ACL; Schema: public; Owner: postgres
--

ALTER DEFAULT PRIVILEGES FOR ROLE postgres IN SCHEMA public GRANT ALL ON SEQUENCES TO poo_user;


--
-- TOC entry 2064 (class 826 OID 92686)
-- Name: DEFAULT PRIVILEGES FOR TABLES; Type: DEFAULT ACL; Schema: public; Owner: postgres
--

ALTER DEFAULT PRIVILEGES FOR ROLE postgres IN SCHEMA public GRANT ALL ON TABLES TO poo_user;

